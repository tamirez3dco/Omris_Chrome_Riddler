using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace SuspenderLib
{

    public class EnglishLetter
    {
        //public static Dictionary<char,NAudio.Wave.WaveStream> audioStreams;
        public static Dictionary<char, SoundPlayer> audioStreams;

        public static void init_english_sounds()
        {
            audioStreams = new Dictionary<char, SoundPlayer>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                String path = Processer.mainResourcesPath + "letters_sounds" + Path.DirectorySeparatorChar + c + ".wav";
                audioStreams[c] = new SoundPlayer(path);
                audioStreams[c].Load();
                //audioStreams[c] = new NAudio.Wave.WaveFileReader(path);
            }
        }
    }
}
