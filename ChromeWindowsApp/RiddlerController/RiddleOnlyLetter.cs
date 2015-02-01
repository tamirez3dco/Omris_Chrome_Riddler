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

namespace RiddlerController
{
    public partial class RiddleOnlyLetter : RiddleWordFirst
    {
        public RiddleOnlyLetter()
        {
            InitializeComponent();
        }

        public override void setup_riddle()
        {
            Logger.Log("RiddlerController.RiddleOnlyLetter.setup_riddle()-started");
            //word_player = new SoundPlayer(Processer.mainResourcesPath + @"letters_sounds\" + chosenWord.filename + ".wav");
            //word_player.Load();
            Logger.Log("RiddlerController.RiddleOnlyLetter.setup_riddle()-ended");
        }

        public override void display_riddle()
        {
            Logger.Log("RiddlerController.RiddleOnlyLetter.display_riddle()-started");
            riddleRichTextBox.Text = chosenWord.getUnicodeWord();
            riddleRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            answerRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            answerRichTextBox.Select();
            answerRichTextBox.Focus();
            //word_player.Play();
            Logger.Log("RiddlerController.RiddleOnlyLetter.display_riddle()-ended");
            
        }
        public override void play_sounds()
        {
            Logger.Log("RiddlerController.RiddleOnlyLetter.play_sounds()-started");
            word_player.Play();
            Logger.Log("RiddlerController.RiddleOnlyLetter.play_sounds()-ended");
           
        }

        private void RiddleOnlyLetter_Load(object sender, EventArgs e)
        {
            Logger.Log("RiddlerController.RiddleOnlyLetter.RiddleOnlyLetter_Load()-started");

        }

        private void RiddleOnlyLetter_MouseClick(object sender, MouseEventArgs e)
        {
            Logger.Log("RiddlerController.RiddleOnlyLetter.RiddleOnlyLetter_MouseClick()-started");

        }
    }
}
