using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SuspenderLib
{
    public partial class EnglishSingleLetterForm : BasicRddleForm
    {
        public EnglishSingleLetterForm()
        {
            InitializeComponent();
        }

        public override void do_whatever_on_show()
        {
            base.do_whatever_on_show();
            display_richTextBox.Text = riddleWord.english_chars;
        }

        //private NAudio.Wave.DirectSoundOut output = null;

        public override bool check_keystroke(KeyEventArgs e)
        {
            Logger.Log("SuspenderLib.EnglishSingleLetterForm.check_keystroke(e.KeyCode=" + e.KeyCode.ToString() + ", e.KeyValue=" + e.KeyValue.ToString() + ")");

            if (riddleAboutToClose) return false;
            if (reject_key_pressing) return false;

            if ((e.KeyCode.ToString().Length > 1)) return false;
            if ((e.KeyCode.ToString().ToUpper()[0] < 'A') || (e.KeyCode.ToString().ToUpper()[0] > 'Z')) return false;

            reject_key_pressing = true;

            answer_richTextBox.Text = e.KeyCode.ToString().ToUpper();
            EnglishLetter.audioStreams[e.KeyCode.ToString().ToLower()[0]].Play();

            answerWasCorrect = (answer_richTextBox.Text.Trim() == display_richTextBox.Text.Trim());

            letterStoppedTimer.Interval = 1000;
            letterStoppedTimer.Start();
            return true;
        }
    }
}
