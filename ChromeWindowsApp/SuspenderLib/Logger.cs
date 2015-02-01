using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SuspenderLib
{
    public class Logger
    {
        public static String LoggerFileLocation = String.Empty;
        public static void Log(String msg)
        {
            String LoggerFileName = @"RiddleLog.txt";
            String completePath = LoggerFileLocation + Path.DirectorySeparatorChar + LoggerFileName;
            try
            {
                using (StreamWriter sw = new StreamWriter(completePath, true))
                {
                    String msgToWrite = DateTime.Now.ToString("hh:mm:ss.fff") + " : " + msg;
                    sw.WriteLine(msgToWrite);
                }
            }
            catch (Exception e)
            {

            }
 
        }
    }
}
