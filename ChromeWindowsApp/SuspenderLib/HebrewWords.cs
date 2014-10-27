using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HAVARA = System.Collections.Generic.List<int>;
using System.IO;
using System.Web.Script.Serialization;

namespace SuspenderLib
{

    public class HebrewWord
    {

        public String english_chars { get; set; }
        public String filename { get; set; }
        public List<HAVARA> havaras { get; set; }
        public int riddle_type { get; set; }


        public HebrewWord()
        {
        }

        public HebrewWord(String english_chars, String file_name, List<HAVARA> havaras)
        {
            this.english_chars = english_chars;
            this.filename = file_name;
            this.havaras = havaras;
        }

       public static List<HebrewWord> wordsInGame;

       public static void initGameWords()
        {
            HebrewLetters.initCapLetterToUnicode();
            //String path = @"C:\Users\tamirlev\Documents\Visual Studio 2010\Projects\ChromeWindowsApp\SuspenderLib\RiddlesList.txt";
            String content = File.ReadAllText(Processer.listPath);
            JavaScriptSerializer serlizer = new JavaScriptSerializer();
            wordsInGame = serlizer.Deserialize<List<HebrewWord>>(content);
        }

        public static HebrewWord getRandomHebrewWord(bool debug = false)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int chosenIndex = rnd.Next(0, wordsInGame.Count);
            if (chosenIndex == wordsInGame.Count) chosenIndex--;

            if (debug) chosenIndex = 1;

            return wordsInGame[chosenIndex];
        }

        public String getUnicodeWord()
        {
            String res = String.Empty;
            foreach (Char c in this.english_chars)
            {
                res += HebrewLetters.capLetterToHebrewUnicode[c];
            }
            return res;
        }
    }
}
