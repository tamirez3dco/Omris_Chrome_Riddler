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

    public struct WordStruct
    {
        public HebrewWord answer_hebrew_word;
        public PictureBox answer_pictureBox;
        public Panel sorroundingPanel;
        public SoundPlayer sound;
        public int row;
        public int col;
    }
    public partial class ImageToWordForm : BasicRddleForm
    {
        public List<WordStruct> answersStructs = new List<WordStruct>();
        public int num_of_answers; 

        HebrewWord[] answers = new HebrewWord[4];
        PictureBox[] ansPictures = new PictureBox[4];
        Panel[] picPanels = new Panel[4];
        SoundPlayer[] players = new SoundPlayer[4];

        int[] mesichimIndexes = new int[3];
        int correctIndex = 0;
        int correctIndex2 = 0;

        public ImageToWordForm()
        {
            InitializeComponent();
        }

        private void ImageToWordForm_Load(object sender, EventArgs e)
        {
        }

        public void chooseAllAnswersStructs()
        {
            // GET all optional messichim 
            List<int> optional_mesichim = new List<int>();
            List<int> same_letter_mesichim = new List<int>();

            for (int i = 0; i < HebrewWord.wordsDB.Count; i++)
            {
                if (this.riddleWord.filename == HebrewWord.wordsDB[i].filename)
                {

                    continue;
                }
                if (this.riddleWord.getUnicodeWord()[0] == HebrewWord.wordsDB[i].getUnicodeWord()[0])
                {
                    same_letter_mesichim.Add(i);
                }
                optional_mesichim.Add(i);
            }

            List<int> indexes_before_permutation = new List<int>();
            for (int i = 0; i < num_of_answers - 1; i++)
            {
                List<int> currentList = optional_mesichim;
                if ((same_letter_mesichim.Count > 0) && (i < 2))
                {
                    currentList = same_letter_mesichim;
                }

                int next_Mesiach_Index = Randomer.randomer.Next(0, currentList.Count);
                int chosenNumber = currentList[next_Mesiach_Index];
                indexes_before_permutation.Add(chosenNumber);

                if (optional_mesichim.Contains(chosenNumber)) optional_mesichim.Remove(chosenNumber);
                if (same_letter_mesichim.Contains(chosenNumber)) same_letter_mesichim.Remove(chosenNumber);
            }

            List<int> chsenPermutation = choose_perm(num_of_answers);

            int[] length_rows = {num_of_answers,0};
            if (num_of_answers > 4)
            {
                length_rows[0] = (num_of_answers + 1) / 2;
            }
            length_rows[1] = num_of_answers - length_rows[0];
            int middleForm = this.Width / 2;
            Size picSize = new Size(230,160);
            Size panelSize = new Size(picSize.Width + 20, picSize.Height + 20);

            for (int i = 0; i < num_of_answers; i++)
            {
                WordStruct ws = new WordStruct();
                ws.row = 0;
                if (i >= length_rows[0]) ws.row = 1;
                if (ws.row == 0) ws.col = i % length_rows[0];
                else ws.col = i - length_rows[0];

                Panel newPanel = new Panel();
                newPanel.Name = "borderPanel" + i.ToString();
                newPanel.Size = panelSize;
                Point panelLocation = new Point();
                panelLocation.X = 10 + ws.col * panelSize.Width;
                int cubesInRowToFill4 = 4 - length_rows[ws.row];
                panelLocation.X += cubesInRowToFill4 * (panelSize.Width / 2);
                panelLocation.Y = 230 + ws.row * panelSize.Height;
                newPanel.Location = panelLocation;
                newPanel.BackColor = Color.Orange;
                //newPanel.SendToBack();
                newPanel.Visible = false;

                ws.sorroundingPanel = newPanel;


                PictureBox pb = new PictureBox();
                pb.Size = picSize;
                Point picLocation = new Point();
                picLocation.X = panelLocation.X + (panelSize.Width - picSize.Width) / 2;
                picLocation.Y = panelLocation.Y + (panelSize.Height - picSize.Height) / 2;
                pb.Location = picLocation;
                pb.BackColor = Color.Black;
                pb.Name = "pb" + i.ToString();
                pb.MouseEnter += whenMouseEnter;
                pb.MouseLeave += whenMouseLeaves;
                pb.MouseClick += pictureClicked;
                pb.Visible = true;
                //pb.BringToFront();
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                ws.answer_pictureBox = pb;

                this.Controls.Add(ws.sorroundingPanel);
                this.Controls.Add(ws.answer_pictureBox);
                this.Controls.SetChildIndex(ws.sorroundingPanel, 10);
                this.Controls.SetChildIndex(ws.answer_pictureBox, 0);

                answersStructs.Add(ws);
            }

            for (int i = 0; i < num_of_answers; i++)
            {
                int chosenIndex = chsenPermutation[i];
                WordStruct ws = answersStructs[chosenIndex];

                if (i == 0)
                {
                    ws.answer_hebrew_word = riddleWord;
                    correctIndex2 = chosenIndex;
                }
                else
                {
                    ws.answer_hebrew_word = HebrewWord.wordsDB[indexes_before_permutation[i-1]];
                }

                ws.answer_pictureBox.Image = HebrewWordForm.LoadBitmap(Processer.mainResourcesPath + @"words_sounds\" + ws.answer_hebrew_word.filename + ".jpg");
                ws.sound = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + ws.answer_hebrew_word.filename + ".wav");
                ws.sound.Load();
                answersStructs[chosenIndex] = ws;
            }

/*
            HebrewWord hw = HebrewWord.wordsDB[indexes_before_permutation[chsenPermutation[i]]];
            ws.answer_hebrew_word = hw;
            ws.answer_pictureBox.Image = HebrewWordForm.LoadBitmap(Processer.mainResourcesPath + @"words_sounds\" + ws.answer_hebrew_word.filename + ".jpg");
            ws.sound = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + answers[i].filename + ".wav");
            ws.sound.Load();


            answersStructs.Add(ws);
*/
            int permutation_index = Randomer.randomer.Next(0, 24);

            answers[permutator[permutation_index, 0]] = riddleWord;
            correctIndex = permutator[permutation_index, 0];
            answers[permutator[permutation_index, 1]] = HebrewWord.wordsDB[mesichimIndexes[0]];
            answers[permutator[permutation_index, 2]] = HebrewWord.wordsDB[mesichimIndexes[1]];
            answers[permutator[permutation_index, 3]] = HebrewWord.wordsDB[mesichimIndexes[2]];

/*
            for (int i = 0; i < 4; i++)
            {
                Debug.WriteLine("i=" + i);
                Debug.WriteLine("ansPictures[i]=" + ansPictures[i].ToString());
                Debug.WriteLine("answers[i]=" + answers[i].ToString());

                ansPictures[i].Image = HebrewWordForm.LoadBitmap(Processer.mainResourcesPath + @"words_sounds\" + answers[i].filename + ".jpg");
                players[i] = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + answers[i].filename + ".wav");
                players[i].Load();
            }

  */          
            
            for (int i = 0; i < num_of_answers; i++)
            {

            }
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

        public List<int> choose_perm(int size)
        {
            List<int> res = new List<int>();

            List<int> helper = new List<int>();
            for (int i = 0; i < size; i++)
            {
                helper.Add(i);
            }

            for (int i = 0; i < size; i++)
            {
                int index_to_remove = Randomer.randomer.Next(0, helper.Count);
                res.Add(helper[index_to_remove]);
                helper.RemoveAt(index_to_remove);
            }

            return res;
        }

        public override void do_whatever_on_show()
        {

            chooseAllAnswersStructs();
//            return;


            this.Size = this.MinimumSize = this.MaximumSize = new Size(1050, 650);
            playWordSoundOnClick = false;

            display_Label.Font = BasicRddleForm.checkFontSizeForStringControl(riddleWord.getUnicodeWord(), display_Label);
            display_Label.Text = riddleWord.getUnicodeWord();
        }

        private void pictureClicked(object sender, EventArgs e)
        {
            String senderName = ((PictureBox)sender).Name;
            Debug.WriteLine("Mouse clicked " + senderName);

            int senderIndex = int.Parse(senderName.Substring(2));
            Debug.WriteLine("senderName=" + senderName + ", senderIndex=" + senderIndex + " correctIndex2= " + correctIndex2);
            answerWasCorrect = (senderIndex == correctIndex2);
            letterStoppedTimer.Interval = 1500;
            letterStoppedTimer.Start();
            answersStructs[senderIndex].sound.Play();

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
                foreach (WordStruct ws in answersStructs)
                {
                    ws.answer_pictureBox.Visible = false;
                }
                this.BackColor = Color.Black;
                fuckupTimer.Start();
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

        private void whenMouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("whenMouseEnter:" + ((Control)sender).Name);
            String senderName = ((PictureBox)sender).Name;
            String subName = senderName.Substring(2);
            String panelName = "borderPanel" + subName;
            Control panel = this.Controls[panelName];
            panel.Visible = true;
        }

        private void whenMouseLeaves(object sender, EventArgs e)
        {
            Debug.WriteLine("whenMouseLeaves:" + ((Control)sender).Name);
            String senderName = ((PictureBox)sender).Name;
            String subName = senderName.Substring(2);
            String panelName = "borderPanel" + subName;
            Control panel = this.Controls[panelName];
            panel.Visible = false;
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
            fuckupTimer.Stop();
            this.BackColor = origBack;
            foreach (WordStruct ws in answersStructs)
            {
                ws.answer_pictureBox.Visible = true;
            }
            this.Refresh();
        }

        public override void BasicRiddleForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        public override void BasicRiddlerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}