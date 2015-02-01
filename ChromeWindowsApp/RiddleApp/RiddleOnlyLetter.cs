using SuspenderLib;
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

namespace RiddleApp
{
    public partial class RiddleOnlyLetter : RiddleWordFirst
    {
        public RiddleOnlyLetter()
        {
            InitializeComponent();
        }

        public override void setup_riddle()
        {
            riddleRichTextBox.Text = chosenWord.getUnicodeWord();
            riddleRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            answerRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            answerRichTextBox.Select();
            answerRichTextBox.Focus();
            word_player = new SoundPlayer(Processer.mainResourcesPath + @"letters_sounds\" + chosenWord.filename + ".wav");
            word_player.Load();
            havara_players = new List<SoundPlayer>();
            word_player.Play();
        }

    }
}
