using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuspenderLib
{
    public class HebrewLetters
    {
        public static Dictionary<char, String> capLetterToHebrewUnicode;
        //public static Char[] capLetters;
        public static void initCapLetterToUnicode()
        {
            capLetterToHebrewUnicode = new Dictionary<char, string>();
            capLetterToHebrewUnicode['E'] = "\u05E7";
            capLetterToHebrewUnicode['R'] = "\u05E8";
            capLetterToHebrewUnicode['T'] = "\u05D0";
            capLetterToHebrewUnicode['Y'] = "\u05D8";
            capLetterToHebrewUnicode['U'] = "\u05D5";
            capLetterToHebrewUnicode['I'] = "\u05DF";
            capLetterToHebrewUnicode['O'] = "\u05DD";
            capLetterToHebrewUnicode['P'] = "\u05E4";

            capLetterToHebrewUnicode['A'] = "\u05E9";
            capLetterToHebrewUnicode['S'] = "\u05D3";
            capLetterToHebrewUnicode['D'] = "\u05D2";
            capLetterToHebrewUnicode['F'] = "\u05DB";
            capLetterToHebrewUnicode['G'] = "\u05E2";
            capLetterToHebrewUnicode['H'] = "\u05D9";
            capLetterToHebrewUnicode['J'] = "\u05D7";
            capLetterToHebrewUnicode['K'] = "\u05DC";
            capLetterToHebrewUnicode['L'] = "\u05DA";
            capLetterToHebrewUnicode[':'] = "\u05E3";

            capLetterToHebrewUnicode['Z'] = "\u05D6";
            capLetterToHebrewUnicode['X'] = "\u05E1";
            capLetterToHebrewUnicode['C'] = "\u05D1";
            capLetterToHebrewUnicode['V'] = "\u05D4";
            capLetterToHebrewUnicode['B'] = "\u05E0";
            capLetterToHebrewUnicode['N'] = "\u05DE";
            capLetterToHebrewUnicode['M'] = "\u05E6";
            capLetterToHebrewUnicode['<'] = "\u05EA";
            capLetterToHebrewUnicode['>'] = "\u05E5";

            capLetterToHebrewUnicode[' '] = "\u0020";
            //capLetters = capLetterToHebrewUnicode.Keys.ToArray();
        }
    }
}
