using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    
    public partial class BasicRddleForm : Form
    {
        public SoundPlayer buzzer_player;
        public SoundPlayer gling_player;
        public SoundPlayer kolkavod_player;

        public HebrewWord riddleWord;
        public SoundPlayer word_player;
        public bool reject_key_pressing;
        public bool answerWasCorrect = false;
        public int letters_counter = 0;

        public bool play_havaras_when_shown = false;
        public List<System.Media.SoundPlayer> havara_players;
        int havara_counter = 0;
        public bool riddleAboutToClose = false;
        public bool playWordSoundOnClick = true;

        public HorizontalAlignment desired_alignment = HorizontalAlignment.Center;

        public void PlayHavara()
        {
            soundStopperTimer.Stop();
            if (havara_counter > riddleWord.havaras.Count * 2)
            {
                display_richTextBox.Select(riddleWord.english_chars.Length, 0);
                answer_richTextBox.Focus();
                soundStopperTimer.Stop();
                return;
            }
            else
            {
                if (havara_counter == riddleWord.havaras.Count * 2)
                {
                    display_richTextBox.Select(0, riddleWord.english_chars.Length);
                    word_player.Play();
                }
                else
                {
                    List<int> havara = riddleWord.havaras[havara_counter % riddleWord.havaras.Count];
                    display_richTextBox.Select(havara[0], havara[1] - havara[0] + 1);
                    havara_players[havara_counter % riddleWord.havaras.Count].Play();
                }
            }
            soundStopperTimer.Interval = 1300;
            soundStopperTimer.Start();
        }

        public virtual void load_riddle_sounds_into_dict()
        {
            String temp = "words_sounds";
            if (this.GetType() == typeof(BasicRddleForm) || this.GetType() == typeof(EnglishSingleLetterForm)) temp = "letters_sounds";
            String word_sound_path = Processer.mainResourcesPath + temp + Path.DirectorySeparatorChar + riddleWord.filename + ".wav";
            word_player = new System.Media.SoundPlayer(word_sound_path);
            word_player.Load();

            if (play_havaras_when_shown)
            {
                havara_players = new List<SoundPlayer>();
                for (int i = 0; i < riddleWord.havaras.Count; i++)
                {
                    SoundPlayer nextHavaraPlayer = new SoundPlayer(Processer.mainResourcesPath + @"words_sounds\" + riddleWord.filename + "_" + i.ToString() + ".wav");
                    nextHavaraPlayer.Load();
                    havara_players.Add(nextHavaraPlayer);
                }
            }
            return;
        }

        public virtual void init_form_by_riddle_word(HebrewWord riddleWord)
        {
            this.riddleWord = riddleWord;
        }

        public BasicRddleForm()
        {
            InitializeComponent();
            display_richTextBox.SelectionBackColor = Color.Red;
            display_richTextBox.SelectionColor = Color.White;

        }


        public virtual void do_whatever_on_show()
        {
            try
            {
                // disable resizing
                this.FormBorderStyle = FormBorderStyle.FixedSingle;

                // for allignsment to center
                display_richTextBox.SelectAll();
                display_richTextBox.SelectionAlignment = desired_alignment;
                display_richTextBox.Select(0, 0);

                // TBD - hide Caret
                display_richTextBox.Font = BasicRddleForm.checkFontSizeForStringControl(riddleWord.getUnicodeWord(), display_richTextBox);
                answer_richTextBox.Font = BasicRddleForm.checkFontSizeForStringControl(riddleWord.getUnicodeWord(), answer_richTextBox);

                // fill word
                display_richTextBox.Text = riddleWord.getUnicodeWord();

                // for allignsment to center
                answer_richTextBox.SelectAll();
                answer_richTextBox.SelectionAlignment = desired_alignment;
                answer_richTextBox.Select(0, 0);
                answer_richTextBox.Focus();

                next_correct_key = riddleWord.english_chars[0];
                delay_first_sound_timer.Start();

                make_sure_window_on_top();
            }
            catch (Exception exc)
            {
            }
        }
        public void BasicRiddleForm_Load(object sender, EventArgs e)
        {
            //in Single size
            this.Size = new System.Drawing.Size(500, 400);
            do_whatever_on_show();

        }


        public void make_sure_window_on_top()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            answer_richTextBox.Focus();
        }
        public virtual void delay_first_sound_timer_Tick(object sender, EventArgs e)
        {
            delay_first_sound_timer.Stop();
            if (play_havaras_when_shown) PlayHavara();
            else word_player.Play();
        }

        public static Font checkFontSizeForStringControl(String s, Control c)
        {
            Font f = c.Font;
            int trySize = (int)f.Size;
            Font tryFont = new Font(f.FontFamily, trySize);
            while (c.CreateGraphics().MeasureString(s, tryFont).Width > c.Width - 10)
            {
                trySize -= 5;
                tryFont = new Font(f.FontFamily, trySize);
            }
            return tryFont;
        }


        public virtual bool check_keystroke(KeyEventArgs e)
        {
            Logger.Log("SuspenderLib.BasicRiddleForm.check_keystroke(e.KeyCode=" + e.KeyCode.ToString() + ", e.KeyValue=" + e.KeyValue.ToString() + ")");

            if (riddleAboutToClose) return false;
            if (reject_key_pressing) return false;
            if (!HebrewLetter.hebrewLettersDict.ContainsKey(e.KeyValue)) return false;

            reject_key_pressing = true;

            answer_richTextBox.Text += HebrewLetter.hebrewLettersDict[e.KeyValue].unicode;
            HebrewLetter.hebrewLettersDict[e.KeyValue].sound.Play();

            answerWasCorrect = keyPressWasCorrect(HebrewLetter.hebrewLettersDict[e.KeyValue].english_char[0]);

            letterStoppedTimer.Interval = HebrewLetter.hebrewLettersDict[e.KeyValue].duration;
            letterStoppedTimer.Start();
            return true;
        }

        public virtual void BasicRiddleForm_KeyDown(object sender, KeyEventArgs e)
        {
            answer_richTextBox_KeyDown(sender, e);
            return;
        }

        public char next_correct_key;
        public virtual bool keyPressWasCorrect(char eng_chr_pressed)
        {

            return eng_chr_pressed == next_correct_key;
        }


        public void play_kolkavod_and_set_close_timers()
        {
            riddleAboutToClose = true;

            kolkavod_player.Play();
            kol_kavod_Timer.Start();
        }

        public virtual void letterStoppedTimer_Tick(object sender, EventArgs e)
        {
            // check if answer was correct
            letterStoppedTimer.Stop();
            if (riddleAboutToClose) return;
            reject_key_pressing = false;
            if (answerWasCorrect)
            {
                letters_counter++;
                gling_player.Play();
                if (letters_counter == riddleWord.english_chars.Length)
                {
                    play_kolkavod_and_set_close_timers();
                    return;
                }
                else
                {
                    next_correct_key = riddleWord.english_chars[letters_counter];
                }
            }
            else
            {
                //fuckups++;  // meantime useless
                buzzer_player.Play();
            }
            answer_richTextBox.Text = riddleWord.getUnicodeWord().Substring(0,letters_counter);
        }

        private void kol_kavod_Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void answer_richTextBox_Click(object sender, EventArgs e)
        {
            if (playWordSoundOnClick)  word_player.Play();
        }

        private void display_richTextBox_Click(object sender, EventArgs e)
        {
            if (playWordSoundOnClick) word_player.Play();
        }

        public virtual void BasicRiddlerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            answer_richTextBox_KeyPress(sender, e);
            return;
        }

        private void BasicRiddleForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (playWordSoundOnClick)  word_player.Play();
        }


        private void answer_richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Logger.Log("SuspenderLib.answer_richTextBox_KeyDown(e.KeyCode=" + e.KeyCode.ToString() + ", e.KeyValue=" + e.KeyValue.ToString() + ")");

            e.Handled = true;

            if (reject_key_pressing) return;
            check_keystroke(e);
            return;
        }

        private void answer_richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public virtual void display_richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            answer_richTextBox_KeyDown(sender, e);
            return;
        }

        public virtual void display_richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void soundStopperTimer_Tick(object sender, EventArgs e)
        {
            soundStopperTimer.Stop();
            havara_counter++;
            PlayHavara();
        }


    }
}
