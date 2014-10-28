using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;
using SuspenderLib;

namespace RiddleApp
{
    public partial class RiddleFirstLetter : RiddleForm
    {
        public RiddleFirstLetter()
        {
            InitializeComponent();
        }

        public override void setup_riddle()
        {
            base.setup_riddle();
            answerRichTextBox.Text = "_" + chosenWord.getUnicodeWord().Substring(1, chosenWord.english_chars.Length - 1);
            word_player = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".wav");
            word_player.Load();
            word_player.Play();
        }

        int bleep_index = 0;
        private void bleepTimer_Tick(object sender, EventArgs e)
        {
//            Debug.WriteLine("changebleepTimer_Tick()");
            if (bleep_index == 0)
            {
                //Debug.WriteLine("Slecting(0,1)");
                answerRichTextBox.Select(0, 1);
                answerRichTextBox.SelectionBackColor = Color.White;
                answerRichTextBox.SelectionColor = Color.White;
            }
            else
            {
                //Debug.WriteLine("Deslecting");
                answerRichTextBox.DeselectAll();
            }

            bleep_index = (bleep_index + 1) % 2;
            return;
        }

        private void RiddleFirstLetter_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (reject_key_pressing) return;

            // play letter
            //char englishChar = HebrewLetter.hebrewLetters
            Debug.WriteLine(e.KeyCode.ToString());
            Debug.WriteLine(e.KeyValue.ToString());

            Debug.WriteLine("------------------");
            if (!HebrewLetter.hebrewLettersDict.ContainsKey(e.KeyValue)) return;

            reject_key_pressing = true;
            HebrewLetter.hebrewLettersDict[e.KeyValue].sound.Play();
            
            
            answerWasCorrect =  (e.KeyCode.ToString()[0] == chosenWord.english_chars[0]);
            if (answerWasCorrect)
            {
                answerRichTextBox.SelectAll();
                answerRichTextBox.SelectionColor = Color.Black;
                answerRichTextBox.SelectionBackColor = Color.White;

                answerRichTextBox.Text = chosenWord.getUnicodeWord();
                bleepTimer.Stop();
                answerRichTextBox.DeselectAll();

            }
            letterStoppedTimer.Interval = HebrewLetter.hebrewLettersDict[e.KeyValue].duration;
            letterStoppedTimer.Start();
        }

        public override void virtual_letterStoppedTimer_Tick(object sender, EventArgs e)
        {
            letterStoppedTimer.Stop();
            reject_key_pressing = false;
            if (answerWasCorrect)
            {
                gling_player.Play();
                play_kolkavod_and_set_close_timers();

            }
            else
            {
                fuckups++;
                //if (fuckups < 3)
                //{
                buzzer_player.Play();
                //}
            }

        }

        private void RiddleFirstLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void RiddleFirstLetter_Load(object sender, EventArgs e)
        {
            answerRichTextBox.SelectionBackColor = Color.White;
            answerRichTextBox.SelectionColor = Color.White;
            bleepTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            answerRichTextBox.SelectAll();
            answerRichTextBox.SelectionBackColor = Color.Red;
        }


        private void riddleImage_MouseClick(object sender, MouseEventArgs e)
        {
            word_player.Play();
        }

        private void answerRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            word_player.Play();
        }





    }
}
