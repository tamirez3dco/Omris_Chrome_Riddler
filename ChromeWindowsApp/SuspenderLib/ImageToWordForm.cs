using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class ImageToWordForm : BasicRddleForm
    {
        HebrewWord[] answers = new HebrewWord[4];
        PictureBox[] ansPictures = new PictureBox[4];
        Panel[] picPanels = new Panel[4];
        SoundPlayer[] players = new SoundPlayer[4];

        int[] mesichimIndexes = new int[3];
        int correctIndex = 0;

        public ImageToWordForm()
        {
            InitializeComponent();
        }

        private void ImageToWordForm_Load(object sender, EventArgs e)
        {
        }

        
        public static void KnuthShuffle<T>(T[] array)
        {
            System.Random random = new System.Random();
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
                T temp = array[i]; array[i] = array[j]; array[j] = temp;
            }
        }

        static public int[,] permutator = { { 0, 1, 2, 3 }, { 0, 1, 3, 2 }, { 0, 2, 1, 3 }, { 0, 2, 3, 1 }, { 0, 3, 1, 2 }, { 0, 3, 2, 1 }, { 1, 0, 2, 3 }, { 1, 0, 3, 2 }, { 1, 2, 0, 3 }, { 1, 2, 3, 0 }, { 1, 3, 0, 2 }, { 1, 3, 2, 0 }, { 2, 0, 1, 3 }, { 2, 0, 3, 1 }, { 2, 1, 0, 3 }, { 2, 1, 3, 0 }, { 2, 3, 0, 1 }, { 2, 3, 1, 0 }, { 3, 0, 1, 2 }, { 3, 0, 2, 1 }, { 3, 1, 0, 2 }, { 3, 1, 2, 0 }, { 3, 2, 0, 1 }, { 3, 2, 1, 0 } };


        public override void do_whatever_on_show()
        {
            this.Size = this.MinimumSize = this.MaximumSize = new Size(1050, 550);
            playWordSoundOnClick = false;

            ansPictures[0] = pictureBox0;
            ansPictures[1] = pictureBox1;
            ansPictures[2] = pictureBox2;
            ansPictures[3] = pictureBox3;

            picPanels[0] = picturePanel0;
            picPanels[1] = picturePanel1;
            picPanels[2] = picturePanel2;
            picPanels[3] = picturePanel3;

            display_Label.Text = riddleWord.getUnicodeWord();


            // GET 3 more images
            List<int> optional_mesichim = new List<int>();
            for (int i = 0; i < HebrewWord.wordsDB.Count; i++)
            {
                if (this.riddleWord.filename == HebrewWord.wordsDB[i].filename)
                {

                    continue;
                }
                optional_mesichim.Add(i);
            }

            Random randomer = new Random();
            int nextMwsiachndex = randomer.Next(0,optional_mesichim.Count);
            mesichimIndexes[0] = optional_mesichim[nextMwsiachndex];
            optional_mesichim.RemoveAt(nextMwsiachndex);

            nextMwsiachndex = randomer.Next(0,optional_mesichim.Count);
            mesichimIndexes[1] = optional_mesichim[nextMwsiachndex];
            optional_mesichim.RemoveAt(nextMwsiachndex);

            nextMwsiachndex = randomer.Next(0,optional_mesichim.Count);
            mesichimIndexes[2] = optional_mesichim[nextMwsiachndex];
            optional_mesichim.RemoveAt(nextMwsiachndex);


            int permutation_index = randomer.Next(0, 24);

            answers[permutator[permutation_index,0]] = riddleWord;
            correctIndex = permutator[permutation_index, 0];
            answers[permutator[permutation_index, 1]] = HebrewWord.wordsDB[mesichimIndexes[0]];
            answers[permutator[permutation_index, 2]] = HebrewWord.wordsDB[mesichimIndexes[1]];
            answers[permutator[permutation_index, 3]] = HebrewWord.wordsDB[mesichimIndexes[2]];


            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine("i=" + i);
                Debug.WriteLine("ansPictures[i]=" + ansPictures[i].ToString());
                Debug.WriteLine("answers[i]=" + answers[i].ToString());

                ansPictures[i].Image = HebrewWordForm.LoadBitmap(Processer.mainResourcesPath + @"words_sounds\" + answers[i].filename + ".jpg");
                players[i] = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + answers[i].filename + ".wav");
                players[i].Load();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            String senderName = ((PictureBox)sender).Name;
            Debug.WriteLine("Mouse clicked " + senderName);

            int senderIndex = int.Parse(senderName[senderName.Length-1].ToString());
            answerWasCorrect = (senderIndex == correctIndex);
            letterStoppedTimer.Interval = 1500;
            letterStoppedTimer.Start();
            players[senderIndex].Play();
        }

        Color origBack;
        public override void letterStoppedTimer_Tick(object sender, EventArgs e)
        {
            // check if answer was correct
            letterStoppedTimer.Stop();
            if (riddleAboutToClose) return;
            reject_key_pressing = false;
            if (answerWasCorrect)
            {
                gling_player.Play();
                play_kolkavod_and_set_close_timers();
                return;
            }
            else
            {
                origBack = this.BackColor;
                for (int i = 0; i < 4; i++)
                {
                    ansPictures[i].Visible = false;
                    this.BackColor = Color.Black;
                    fuckupTimer.Start();
                }

                //fuckups++;  // meantime useless
                buzzer_player.Play();
            }
        }

        public override void display_richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        public override void display_richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            String senderName = ((PictureBox)sender).Name;
            Debug.WriteLine("Mouse Enter " + senderName);

            int senderIndex = int.Parse(senderName[senderName.Length - 1].ToString());
            picPanels[senderIndex].Visible = true;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            String senderName = ((PictureBox)sender).Name;
            Debug.WriteLine("Mouse Enter " + senderName);

            int senderIndex = int.Parse(senderName[senderName.Length - 1].ToString());
            picPanels[senderIndex].Visible = false;

        }

        private void fuckupTimer_Tick(object sender, EventArgs e)
        {
            this.BackColor = origBack;
            for (int i = 0; i < 4; i++)
            {
                ansPictures[i].Visible = true;
            }
            this.Refresh();
        }
    }
}