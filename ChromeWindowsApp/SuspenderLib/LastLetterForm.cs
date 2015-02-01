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
    public partial class LastLetterForm : FirstLetterForm
    {
        public LastLetterForm()
        {
            InitializeComponent();
        }

        public override void do_whatever_on_show()
        {
            base.do_whatever_on_show();
            next_correct_key = riddleWord.english_chars[riddleWord.english_chars.Length-1];
            answer_richTextBox.Text = riddleWord.getUnicodeWord().Substring(0, riddleWord.english_chars.Length - 1) + "_";

        }
    }
}
