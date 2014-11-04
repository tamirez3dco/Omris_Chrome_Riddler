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

        public int bleep_index = 0;
        public virtual void bleepTimer_Tick(object sender, EventArgs e)
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

        public override bool keyPressWasCorrect(char eng_chr_pressed)
        {
            return (eng_chr_pressed == chosenWord.english_chars[0]);
        }

        public override void changeAnswerText()
        {
            if (answerWasCorrect)
            {
                answerRichTextBox.SelectAll();
                answerRichTextBox.SelectionColor = Color.Black;
                answerRichTextBox.SelectionBackColor = Color.White;

                answerRichTextBox.Text = chosenWord.getUnicodeWord();
                bleepTimer.Stop();
                answerRichTextBox.DeselectAll();

            }
            
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
