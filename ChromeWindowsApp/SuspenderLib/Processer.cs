using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using System.Windows.Forms;
using System.IO;

namespace SuspenderLib
{
    public class Processer
    {
        public static String riddleAppExecutablePath;
        public static String mainParentFolderPath;
        public static String mainResourcesPath;// = @"SoundsImagesVideos\";
        public static String mainPsSuspendPath;// = @"fPssuspend\";
        public static String listPath;
        public static String lettersPath;

        public static void setPathes()
        {
            riddleAppExecutablePath = Path.GetDirectoryName(Application.ExecutablePath); // riddleApp/bin/Debug
            DirectoryInfo riddleAppExecutableDirectoryInfo = new DirectoryInfo(riddleAppExecutablePath);

            mainParentFolderPath = riddleAppExecutableDirectoryInfo.Parent.Parent.Parent.FullName;
            mainResourcesPath = mainParentFolderPath + Path.DirectorySeparatorChar + "SoundsImagesVideos" + Path.DirectorySeparatorChar;
            mainPsSuspendPath = mainParentFolderPath + Path.DirectorySeparatorChar + "Pssuspend" + Path.DirectorySeparatorChar;
            listPath = mainParentFolderPath + Path.DirectorySeparatorChar + "SuspenderLib" + Path.DirectorySeparatorChar + "RiddlesList.txt";
            lettersPath = mainParentFolderPath + Path.DirectorySeparatorChar + "SuspenderLib" + Path.DirectorySeparatorChar + "LettersList.txt";

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
                Debug.WriteLine("Exception on pid=" + process.Id + "  e=" + e.Message);
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
                Debug.WriteLine("url=" + url);
            }


            return true;
        }

        public static void SuspendChrome(bool resume=false)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = mainPsSuspendPath;
            psi.FileName = "pssuspend.exe";
            //psi.UseShellExecute = false;
            if (resume) psi.Arguments = "-r Chrome.exe";
            else psi.Arguments = "Chrome.exe";
            Process.Start(psi);
        }

        public static void KillRiddleApp()
        {
            Debug.WriteLine("KillRiddleApp()");
            SuspenderLib.Processer.setPathes();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = mainPsSuspendPath;
            psi.FileName = "pskill.exe";
            psi.Arguments = "RiddleApp.exe";
            Process.Start(psi);
        }


    }
}
