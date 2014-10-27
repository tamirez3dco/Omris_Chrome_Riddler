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
    public partial class RiddleWordFirst : RiddleForm
    {
        public RiddleWordFirst()
        {
            InitializeComponent();
        }


        int havara_counter = 0;
        public void PlayHavara()
        {
            soundStopperTimer.Stop();
            if (havara_counter > chosenWord.havaras.Count * 2)
            {
                riddleRichTextBox.Select(chosenWord.english_chars.Length, 0);
                answerRichTextBox.Focus();
                soundStopperTimer.Stop();
                return;
            }
            else
            {
                if (havara_counter == chosenWord.havaras.Count * 2)
                {
                    riddleRichTextBox.Select(0, chosenWord.english_chars.Length);
                    word_player.Play();
                }
                else
                {
                    List<int> havara = chosenWord.havaras[havara_counter % chosenWord.havaras.Count];
                    riddleRichTextBox.Select(havara[0], havara[1] - havara[0] + 1);
                    havara_players[havara_counter % chosenWord.havaras.Count].Play();
                }
            }
            soundStopperTimer.Interval = 1300;
            soundStopperTimer.Start();
        }

        public override void setup_riddle()
        {
            riddleRichTextBox.Text = chosenWord.getUnicodeWord();
            riddleImage.Image = new Bitmap(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".jpg");
            havara_players = new List<SoundPlayer>();
            for (int i = 0; i < chosenWord.havaras.Count; i++)
            {
                SoundPlayer nextHavaraPlayer = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + "_" + i.ToString() + ".wav");
                nextHavaraPlayer.Load();
                havara_players.Add(nextHavaraPlayer);
            }
            word_player = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".wav");
            word_player.Load();
            PlayHavara();


                /*
                    StringBuilder sb = new StringBuilder(chosenWord.getUnicodeWord());
                    sb[0] = '_';
                    answerRichTextBox.Text = sb.ToString();
                    answerRichTextBox.Select(0, 1);
                    riddleRichTextBox.Visible = false;
                    riddleImage.Image = new Bitmap(mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".jpg");
                    word_player = new SoundPlayer(mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".wav");
                    word_player.Load();
                    word_player.Play();
*/
        }

        private void answerRichTextBox_TextChanged(object sender, EventArgs e)
        {
            return;
            String answerText = answerRichTextBox.Text;
            String compareToText = riddleRichTextBox.Text;
            Debug.WriteLine("answerText=" + answerText);
            Debug.WriteLine("compareToText=" + compareToText);
            if (!compareToText.StartsWith(answerText))
            {
                // play buzzer + color new letter with red
                buzzer_player.Play();
                answerRichTextBox.Text = answerRichTextBox.Text.Substring(0, answerRichTextBox.Text.Length - 1);
            }
            else
            {
                gling_player.Play();
            }

        }

        public override void virtual_letterStoppedTimer_Tick(object sender, EventArgs e)
        {
            letterStoppedTimer.Stop();
            reject_key_pressing = false;
            if (answerWasCorrect)
            {
                gling_player.Play();
                if (answerRichTextBox.Text == riddleRichTextBox.Text)
                {
                    play_kolkavod_and_set_close_timers();
                }
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


        private void answerRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            answerRichTextBox.Select(answerRichTextBox.Text.Length, 0);
        }

        private void soundStopperTimer_Tick(object sender, EventArgs e)
        {
            soundStopperTimer.Stop();
            havara_counter++;
            PlayHavara();

        }



        private void RiddleWordFirst_KeyDown(object sender, KeyEventArgs e)
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


            answerWasCorrect = (e.KeyCode.ToString()[0] == chosenWord.english_chars[answerRichTextBox.Text.Length]);
            if (answerWasCorrect)
            {
                answerRichTextBox.Text = riddleRichTextBox.Text.Substring(0, answerRichTextBox.Text.Length + 1);
            }
            letterStoppedTimer.Interval = HebrewLetter.hebrewLettersDict[e.KeyValue].duration;
            letterStoppedTimer.Start();

            /*
            e.Handled = true;

            Debug.WriteLine("RiddleWordFirst_KeyDown" + e.KeyCode.ToString());
            if (e.KeyCode.ToString()[0] == chosenWord.english_chars[answerRichTextBox.Text.Length])
            {
                gling_player.Play();
                answerRichTextBox.Text = riddleRichTextBox.Text.Substring(0, answerRichTextBox.Text.Length + 1);
                if (answerRichTextBox.Text == riddleRichTextBox.Text)
                {
                    play_kolkavod_and_set_close_timers();
                }
            }
            else
            {
                buzzer_player.Play();
            }
             * 
             */
            return;

        }

        private void RiddleWordFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


    }
}
