using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class FirstLetterForm : HebrewWordForm
    {
        private int bleep_index;
        public FirstLetterForm()
        {
            InitializeComponent();
        }

        public override void do_whatever_on_show()
        {
            try
            {
                // disable resizing
                this.FormBorderStyle = FormBorderStyle.FixedSingle;


                // for allignsment to center
                answer_richTextBox.SelectAll();
                answer_richTextBox.SelectionAlignment = desired_alignment;
                answer_richTextBox.Select(0, 0);
                answer_richTextBox.Focus();
                // fill word
                answer_richTextBox.Text = "_" + riddleWord.getUnicodeWord().Substring(1, riddleWord.english_chars.Length - 1);

                pictureBox1.Image = new Bitmap(Processer.mainResourcesPath + @"words_sounds\" + riddleWord.filename + ".jpg");

                next_correct_key = riddleWord.english_chars[0];
                delay_first_sound_timer.Start();
                bleepTimer.Start();
            }
            catch (Exception exc)
            {
            }
        }

        private void bleepTimer_Tick(object sender, EventArgs e)
        {
            if (bleep_index == 0)
            {
                answer_richTextBox.SelectionBackColor = Color.Red;
                answer_richTextBox.SelectionColor = Color.White;
                if (this.GetType() == typeof(LastLetterForm)) answer_richTextBox.Select(riddleWord.english_chars.Length-1, 1);
                else answer_richTextBox.Select(0, 1);

            }
            else
            {
                answer_richTextBox.DeselectAll();
            }
            bleep_index = (bleep_index + 1) % 2;
            return;
        }

        public override bool check_keystroke(KeyEventArgs e)
        {
            if (!base.check_keystroke(e)) return false;
            if (this.GetType() == typeof(LastLetterForm)) answer_richTextBox.Text = riddleWord.getUnicodeWord().Substring(0, riddleWord.english_chars.Length - 1) + HebrewLetter.hebrewLettersDict[e.KeyValue].unicode;
            else answer_richTextBox.Text = HebrewLetter.hebrewLettersDict[e.KeyValue].unicode + riddleWord.getUnicodeWord().Substring(1, riddleWord.english_chars.Length - 1);
            
            if (answerWasCorrect)
            {
                bleepTimer.Stop();
                answer_richTextBox.DeselectAll();
            }
            return true;
        }

        public override void letterStoppedTimer_Tick(object sender, EventArgs e)
        {

            base.letterStoppedTimer_Tick(sender, e);
            if (answerWasCorrect)
            {
                answer_richTextBox.Text = riddleWord.getUnicodeWord();
                play_kolkavod_and_set_close_timers();
                return;
            }

            if (this.GetType() == typeof(LastLetterForm)) answer_richTextBox.Text = riddleWord.getUnicodeWord().Substring(0, riddleWord.english_chars.Length - 1) + "_";
            else answer_richTextBox.Text = answer_richTextBox.Text = "_" + riddleWord.getUnicodeWord().Substring(1, riddleWord.english_chars.Length - 1);
            

        }

    }
}
