using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuspenderLib;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Media;

using HAVARA = System.Collections.Generic.List<int>;

namespace RiddlerController
{

    public partial class RiddleForm : Form
    {
        public System.Media.SoundPlayer buzzer_player;
        public System.Media.SoundPlayer gling_player;
        public List<System.Media.SoundPlayer> havara_players;
        public System.Media.SoundPlayer word_player;
        public System.Media.SoundPlayer kolkavod_player;

        public bool reject_key_pressing = false;
        public bool answerWasCorrect = false;


        public RiddleForm()
        {
            Logger.Log("RiddlerController.RiddleForm.RiddleForm()-started");
            InitializeComponent();
            Logger.Log("RiddlerController.RiddleForm.RiddleForm()-ended");
        }


        public HebrewWord chosenWord;
        public void extraInitializations()
        {
            Logger.Log("RiddlerController.RiddleForm.extraInitializations()-started");
/*
            this.Location = new Point(100, 100);
            buzzer_player = new System.Media.SoundPlayer(Processer.mainResourcesPath+"buzzer_x.wav");
            buzzer_player.Load();
            gling_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "GLING.wav");
            gling_player.Load();
            kolkavod_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "kol_hakavod_lemushmush.wav");
            kolkavod_player.Load();
 */ 
            Logger.Log("RiddlerController.RiddleForm.extraInitializations()-ended");

        }

        public virtual void setup_riddle() 
        {
            Logger.Log("RiddlerController.RiddleForm.setup_riddle()-started");
            //riddleImage.Image = new Bitmap(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".jpg");
            Logger.Log("RiddlerController.RiddleForm.setup_riddle()-ended");
        }



        public void play_kolkavod_and_set_close_timers()
        {
            kolkavod_player.Play();
            kol_kavod_Timer.Start();
        }


        public int fuckups = 0;

        public virtual void virtual_letterStoppedTimer_Tick(object sender,EventArgs e){}
        private void letterStoppedTimer_Tick(object sender, EventArgs e)
        {
            virtual_letterStoppedTimer_Tick(sender, e);
        }

        private void kol_kavod_Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual bool keyPressWasCorrect(char eng_chr_pressed)
        {
            return true;
        }

        private bool check_code(Keys k)
        {
            if ((k == Keys.F11) && (code_counter == 0))
            {
                code_counter++;
                return false;
            }
            if ((k == Keys.F9) && (code_counter == 1))
            {
                code_counter++;
                return false;
            }
            if ((k == Keys.F5) && (code_counter == 2))
            {
                //Program.quit = true;
                return true;
            }
            return false;
        }

        int code_counter = 0;
        private void RiddleForm_KeyDown(object sender, KeyEventArgs e)
        {
            Logger.Log("RiddleForm_KeyDown(e.KeyCode=" + e.KeyCode.ToString() + ", e.KeyValue=" + e.KeyValue.ToString()+")");

            e.Handled = true;
            if (check_code(e.KeyCode))
            {
                this.Close();
                return;
            }

            if (reject_key_pressing) return;
            if (!HebrewLetter.hebrewLettersDict.ContainsKey(e.KeyValue)) return;

            reject_key_pressing = true;
            HebrewLetter.hebrewLettersDict[e.KeyValue].sound.Play();

            answerWasCorrect = keyPressWasCorrect(HebrewLetter.hebrewLettersDict[e.KeyValue].english_char[0]);

            changeAnswerText();
            //answerWasCorrect = (HebrewLetter.hebrewLettersDict[e.KeyValue].english_char[0] == chosenWord.english_chars[answerRichTextBox.Text.Length]);

            letterStoppedTimer.Interval = HebrewLetter.hebrewLettersDict[e.KeyValue].duration;
            letterStoppedTimer.Start();
            return;



        }
        public virtual void display_riddle()
        {
        }

        public virtual void play_sounds()
        {
        }

        public virtual void changeAnswerText()
        {
            throw new NotImplementedException();
        }

        private void RiddleForm_MouseDown(object sender, MouseEventArgs e)
        {
            word_player.Play();
        }

        private void riddleImage_Click(object sender, EventArgs e)
        {
            word_player.Play();
        }

        private void RiddleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void playSoundsTimer_Tick(object sender, EventArgs e)
        {
            Logger.Log("RiddlerController.RiddleForm.play_sounds()-started");

            play_sounds();
            Logger.Log("RiddlerController.RiddleForm.play_sounds()-ended");
        }

    }
}
