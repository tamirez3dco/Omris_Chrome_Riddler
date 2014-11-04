using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SuspenderLib;
using System.IO;

namespace RiddleApp
{
    static class Program
    {
        public static bool quit = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            SuspenderLib.Processer.setPathes();


            if (args.Length > 0)
            {
                if (args[0] == "DEBUGME") DEBUGME = true;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SuspenderLib.HebrewWord.initGameWords();
            HebrewLetter.initHebrewLetters();

            while (!quit)
            {
                if (!DEBUGME) System.Threading.Thread.Sleep(15000);
                if (!DEBUGME) Processer.SuspendChrome();
                RiddleForm rf = null;
                HebrewWord chosenWord = SuspenderLib.HebrewWord.getRandomHebrewWord(Program.DEBUGME);
                switch (chosenWord.riddle_type)
                {
                    case 1:
                        rf = new RiddleWordFirst(); 
                        break;
                    case 2:
                        rf = new RiddleFirstLetter();
                        break;
                    case 3:
                        rf = new RiddleLastLetter();
                        break;
                }
                rf.extraInitializations();
                rf.chosenWord = chosenWord;
                rf.setup_riddle();
                Application.Run(rf);
                System.Diagnostics.Debug.WriteLine("After Run");
                if (!DEBUGME) Processer.SuspendChrome(true);

                
                if (!DEBUGME) System.Threading.Thread.Sleep(105000);
                else System.Threading.Thread.Sleep(5000);
                
                
            }

        }

        public static bool DEBUGME = false; 

    }
}
