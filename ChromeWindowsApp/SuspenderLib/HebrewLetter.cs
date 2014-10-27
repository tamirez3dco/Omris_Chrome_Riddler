using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Web.Script.Serialization;

namespace SuspenderLib
{


    public class HebrewLetter
    {
        public int value { get; set; }
        public String english_char { get; set; }
        public String filename { get; set; }
        public String unicode { get; set; }
        public int duration { get; set; }
        public System.Media.SoundPlayer sound;


        public HebrewLetter()
        {
        }

        public HebrewLetter(int value, String english_char, String file_name, String unicode,int duration)
        {
            this.value = value;
            this.english_char = english_char;
            this.filename = file_name;
            this.unicode = unicode;
            this.duration = duration;
        }

       public static List<HebrewLetter> hebrewLetters;
       public static Dictionary<int,HebrewLetter> hebrewLettersDict;

       public static void initHebrewLetters()
        {
            String content = File.ReadAllText(Processer.lettersPath);
            JavaScriptSerializer serlizer = new JavaScriptSerializer();
            hebrewLetters = serlizer.Deserialize<List<HebrewLetter>>(content);
            hebrewLettersDict = new Dictionary<int, HebrewLetter>();
            foreach (HebrewLetter letter in hebrewLetters)
            {
                letter.sound = new System.Media.SoundPlayer(Processer.mainResourcesPath + Path.DirectorySeparatorChar + "letters_sounds" + Path.DirectorySeparatorChar + letter.filename +".wav");
                letter.sound.Load();
                hebrewLettersDict[letter.value] = letter;
            }

        }
    }
}
