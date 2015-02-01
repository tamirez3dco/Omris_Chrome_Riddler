using SuspenderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiddlerController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SuspenderLib.Processer.setPathes();
            Logger.LoggerFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            SuspenderLib.HebrewWord.initGameWords();
            HebrewLetter.initHebrewLetters();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
