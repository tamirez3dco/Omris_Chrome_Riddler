using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace SuspenderLib
{
    public class Processer
    {

        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);

        [DllImport("user32")]
        private static extern
        IntPtr SendMessage(
                IntPtr handle,
                int Msg,
                IntPtr wParam,
                IntPtr lParam
         );

        private const int WM_CLOSE = 0x0010;
/*
        public void CloseWindowByClassName(string className)
        {
            IntPtr handle = FindWindow(null, className);
            if (handle != IntPtr.Zero)
            {
                SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
*/
        private static void CloseHandle(IntPtr handle)
        {
            if (handle != IntPtr.Zero)
            {
                SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }

 


        public static void ResumeChromes()
        {
            Process[] chromes = Process.GetProcessesByName("chrome");
            foreach (Process p in chromes)
            {

                foreach (ProcessThread pT in p.Threads)
                {
                    IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                    if (pOpenThread == IntPtr.Zero)
                    {
                        continue;
                    }

                    var suspendCount = 0;
                    do
                    {
                        suspendCount = ResumeThread(pOpenThread);
                    } while (suspendCount > 0);

                    CloseHandle(pOpenThread);
                }
            }
        }

        private static void SuspendProcess(int pid)
        {
            var process = Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
        }

        public static void ResumeProcess(int pid)
        {
            var process = Process.GetProcessById(pid);

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);

                CloseHandle(pOpenThread);
            }
        }
        
        
        
        
        
        public static String riddleAppExecutablePath;
        public static String mainResourcesPath;// = @"SoundsImagesVideos\";
        public static String listPath;
        public static String lettersPath;
        public static String mainDataPath;

        public static void setPathes()
        {
            riddleAppExecutablePath = Path.GetDirectoryName(Application.ExecutablePath); // riddleApp/bin/Debug
            DirectoryInfo riddleAppExecutableDirectoryInfo = new DirectoryInfo(riddleAppExecutablePath);

            mainDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + Path.DirectorySeparatorChar + "HAMENAJESET";
            mainResourcesPath = mainDataPath + Path.DirectorySeparatorChar + "SoundsImagesVideos" + Path.DirectorySeparatorChar;
            listPath = mainDataPath + Path.DirectorySeparatorChar + "RiddlesList.txt";
            lettersPath = mainDataPath + Path.DirectorySeparatorChar + "LettersList.txt";
        }


        public static char TranslateKeyArgToEnglishChar(KeyEventArgs key)
        {
            if (key.KeyValue == 186) return ';';
            if (key.KeyValue == 188) return ',';
            if (key.KeyValue == 190) return '.';
            return key.KeyCode.ToString()[0];
        }
        public static string GetChromeUrl(Process process)
        {
            String res = null;

            if (process == null)
                throw new ArgumentNullException("process");

            if (process.MainWindowHandle == IntPtr.Zero)
                return null;

            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;

            try
            {

                AutomationElement edit = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                res = ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            }
            catch (Exception e)
            {
                Logger.Log("Exception on pid=" + process.Id + "  e=" + e.Message);
                return null;
            }

            return res;

        }

        public static bool GetChromesPlayingYouTube()
        {
            Process[] chromeProceses = Process.GetProcessesByName("chrome");
            foreach (Process p in chromeProceses)
            {
                String url = SuspenderLib.Processer.GetChromeUrl(p);
                Logger.Log("url=" + url);
            }


            return true;
        }

        public static void SuspendProcess(String processName, bool resume=false)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            psi.WorkingDirectory = riddleAppExecutablePath;
            psi.FileName = psi.WorkingDirectory + Path.DirectorySeparatorChar + "pssuspend.exe";
            if (resume) psi.Arguments = "-r " + processName;
            else psi.Arguments = processName;
            Process.Start(psi);
        }

        public static void KillRiddleApp()
        {
            Logger.Log("KillRiddleApp()");
            SuspenderLib.Processer.setPathes();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = riddleAppExecutablePath;
            psi.FileName = "taskkill";
            psi.Arguments = "/F /IM RiddleApp.exe";
            Process.Start(psi);
        }


    }

    public static class WavFileUtils
    {
        public static void TrimWavFile(string inPath, string outPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (WaveFileReader reader = new WaveFileReader(inPath))
            {
                using (WaveFileWriter writer = new WaveFileWriter(outPath, reader.WaveFormat))
                {
                    int bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000;

                    int startPos = (int)cutFromStart.TotalMilliseconds * bytesPerMillisecond;
                    startPos = startPos - startPos % reader.WaveFormat.BlockAlign;

                    int endBytes = (int)cutFromEnd.TotalMilliseconds * bytesPerMillisecond;
                    endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
                    int endPos = (int)reader.Length - endBytes;

                    TrimWavFile(reader, writer, startPos, endPos);
                }
            }
        }

        private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.WriteData(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
