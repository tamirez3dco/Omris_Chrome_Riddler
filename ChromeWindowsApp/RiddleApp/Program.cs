using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SuspenderLib;
using System.IO;

namespace RiddleApp
{
    using RiddleType = Int32;
    static class Program
    {
        public static bool quit = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                String tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Logger.LoggerFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                //Logger.Log("RiddleApp.Program.Main(args.Length=" + args.Length.ToString() + ")");
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

                int debug_word_index = 0;
                while (!quit)
                {
                    if (!DEBUGME) System.Threading.Thread.Sleep(15000);
                    if (!DEBUGME) Processer.SuspendProcess("Chrome.exe");
                    RiddleForm rf = null;
                    HebrewWord chosenWord;
                    if (DEBUGME)
                    {
                        chosenWord = HebrewWord.wordsInGame[0][debug_word_index];
                    }
                    else
                    {
                        RiddleType chosenType = new Random().Next(1, 3);
                        List<HebrewWord> chosenList = SuspenderLib.HebrewWord.wordsInGame[chosenType];

                        chosenWord = chosenList[new Random().Next(0, chosenList.Count() - 1)];
                    }
                    
                    switch (chosenWord.riddle_type)
                    {
                        case 0:
                            rf = new RiddleOnlyLetter();
                            break;
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
                    Logger.Log("After Run");
                    if (!DEBUGME) Processer.SuspendProcess("Chrome.exe" ,true);


                    if (!DEBUGME) System.Threading.Thread.Sleep(105000);
                    else System.Threading.Thread.Sleep(2000);
                    if (DEBUGME)
                    {
                        debug_word_index++;
                        if (debug_word_index == HebrewWord.wordsInGame.Count) debug_word_index = 0;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log("Exception on RiddleApp.Main");
                Logger.Log("Exception=" + e.Message);
            }
        }

        public static bool DEBUGME = false; 

    }
}
