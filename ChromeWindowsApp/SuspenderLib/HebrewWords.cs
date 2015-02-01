using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HAVARA = System.Collections.Generic.List<int>;
using System.IO;
using System.Web.Script.Serialization;

namespace SuspenderLib
{
    using RiddleType = Int32;

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

       public static Dictionary<RiddleType,List<HebrewWord>> wordsInGame;

       public static void initGameWords()
        {
            HebrewLetters.initCapLetterToUnicode();
            //String path = @"SuspenderLib\RiddlesList.txt";
            String content = File.ReadAllText(Processer.listPath);
            JavaScriptSerializer serlizer = new JavaScriptSerializer();
            List<HebrewWord> temp_wordsInGame = serlizer.Deserialize<List<HebrewWord>>(content);
            wordsInGame = new Dictionary<RiddleType,List<HebrewWord>>();
            foreach (HebrewWord word in temp_wordsInGame)
            {
                foreach (int riddleType in word.riddle_types)
                {
                    HebrewWord newWord = new HebrewWord(word.english_chars, word.filename, word.havaras);
                    newWord.riddle_type = riddleType;
                    if (!wordsInGame.ContainsKey(riddleType)) wordsInGame[riddleType] = new List<HebrewWord>();
                    wordsInGame[riddleType].Add(newWord);
                }
            }
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
