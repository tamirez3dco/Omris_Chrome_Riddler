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
        public List<int> riddle_types { get; set; }
        public int riddle_type;

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
            //String path = @"SuspenderLib\RiddlesList.txt";
            String content = File.ReadAllText(Processer.listPath);
            JavaScriptSerializer serlizer = new JavaScriptSerializer();
            List<HebrewWord> temp_wordsInGame = serlizer.Deserialize<List<HebrewWord>>(content);
            wordsInGame = new List<HebrewWord>();
            foreach (HebrewWord word in temp_wordsInGame)
            {
                foreach (int riddleType in word.riddle_types)
                {
                    HebrewWord newWord = new HebrewWord(word.english_chars, word.filename, word.havaras);
                    newWord.riddle_type = riddleType;
                    wordsInGame.Add(newWord);
                }
            }
        }

        public static HebrewWord getRandomHebrewWord(bool debug = false)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int chosenIndex = rnd.Next(0, wordsInGame.Count);
            if (chosenIndex == wordsInGame.Count) chosenIndex--;

            //if (debug) chosenIndex = 0;

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
