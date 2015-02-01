using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using SuspenderLib;

namespace RiddlerController
{
    public partial class RiddleLastLetter : RiddleFirstLetter
    {
        public RiddleLastLetter()
        {
            InitializeComponent();
        }

        public override void setup_riddle()
        {
            base.setup_riddle();
            answerRichTextBox.Text = chosenWord.getUnicodeWord().Substring(0, chosenWord.english_chars.Length - 1) + "_";
            word_player = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".wav");
            word_player.Load();
            word_player.Play();
        }

        public override bool keyPressWasCorrect(char eng_chr_pressed)
        {
            return (eng_chr_pressed == chosenWord.english_chars[chosenWord.english_chars.Length - 1]);
        }

        public override void bleepTimer_Tick(object sender, EventArgs e)
        {
            //            Logger.Log("changebleepTimer_Tick()");
            if (bleep_index == 0)
            {
                //Logger.Log("Slecting(0,1)");
                answerRichTextBox.Select(answerRichTextBox.Text.Length-1, 1);
                answerRichTextBox.SelectionBackColor = Color.White;
                answerRichTextBox.SelectionColor = Color.White;
            }
            else
            {
                //Logger.Log("Deslecting");
                answerRichTextBox.DeselectAll();
            }

            bleep_index = (bleep_index + 1) % 2;
            return;
        }
    }
}
