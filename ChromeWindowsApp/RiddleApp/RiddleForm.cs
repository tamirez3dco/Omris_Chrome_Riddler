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

namespace RiddleApp
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
            InitializeComponent();
        }


        public HebrewWord chosenWord;
        public void extraInitializations()
        {
            this.Location = new Point(100, 100);
            buzzer_player = new System.Media.SoundPlayer(Processer.mainResourcesPath+"buzzer_x.wav");
            buzzer_player.Load();
            gling_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "GLING.wav");
            gling_player.Load();
            kolkavod_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "kol_hakavod_lemushmush.wav");
            kolkavod_player.Load();

        }

        public virtual void setup_riddle() 
        {
            riddleImage.Image = new Bitmap(Processer.mainResourcesPath + @"words_sounds\" + chosenWord.filename + ".jpg");
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

        int code_counter = 0;
        private void RiddleForm_KeyDown(object sender, KeyEventArgs e)
        {
           // Debug.WriteLine("RiddleForm_KeyDown()");
            e.Handled = true;
            if ((e.KeyCode == Keys.F11) && (code_counter == 0))
            {
                code_counter++;
                return;
            }
            if ((e.KeyCode == Keys.F9) && (code_counter == 1))
            {
                code_counter++;
                return;
            }
            if ((e.KeyCode == Keys.F5) && (code_counter == 2))
            {
                Program.quit = true;
                this.Close();
            }

        }

        private void RiddleForm_MouseDown(object sender, MouseEventArgs e)
        {
            word_player.Play();
        }

        private void riddleImage_Click(object sender, EventArgs e)
        {
            word_player.Play();
        }

    }
}
