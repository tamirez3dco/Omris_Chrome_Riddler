using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SuspenderLib;

namespace RiddlerController
{
    public partial class Form1 : Form
    {
        RiddleForm rf = null;
        public static bool isRiddlerActive = false;
        public static bool DEBUGME = true;
        int debug_word_index = 0;
        int timeToRiddle;

        public Form1()
        {
            InitializeComponent();
            loadValuesFromCfgFile();
        }

        public void loadValuesFromCfgFile()
        {
            String tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Logger.LoggerFileLocation = tempPath;
            String cfgFilePath = tempPath + Path.DirectorySeparatorChar + "cfgFile.txt";
            if (!File.Exists(cfgFilePath))
            {
                using (StreamWriter sw = new StreamWriter(cfgFilePath))
                {
                    sw.WriteLine("chrome.exe");
                    sw.WriteLine("90");
                    sw.WriteLine("True");
                    sw.WriteLine("False");
                    sw.WriteLine("True");
                    sw.WriteLine("False");
                }
            }
            using (StreamReader sr = new StreamReader(cfgFilePath))
            {
                programToHaltTextBox.Text = sr.ReadLine();
                delayChooserTrackBar.Value = int.Parse(sr.ReadLine());
                checkBox0.Checked = bool.Parse(sr.ReadLine());
                checkBox1.Checked = bool.Parse(sr.ReadLine());
                checkBox2.Checked = bool.Parse(sr.ReadLine());
                checkBox3.Checked = bool.Parse(sr.ReadLine());

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            String tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            String cfgFilePath = tempPath + Path.DirectorySeparatorChar + "cfgFile.txt";
            using (StreamWriter sw = new StreamWriter(cfgFilePath))
            {
                sw.WriteLine(programToHaltTextBox.Text);
                sw.WriteLine(delayChooserTrackBar.Value.ToString());
                sw.WriteLine(checkBox0.Checked);
                sw.WriteLine(checkBox1.Checked);
                sw.WriteLine(checkBox2.Checked);
                sw.WriteLine(checkBox3.Checked);
            }
        }

        private void delayChooserTrackBar_ValueChanged(object sender, EventArgs e)
        {
            DelayLabel.Text = delayChooserTrackBar.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activateTimer.Stop();
            if (!isRiddlerActive)
            {
                // activate riddler
                if (DEBUGME) timeToRiddle = 1;
                else timeToRiddle = 15;

                // Flip buttons
                activateButton.BackColor = Color.IndianRed;
                activateButton.Text = "Stop Riddler";
                isRiddlerActive = true;

                activateTimer.Start();
                initialize_riddle();
            }
            else
            {
                activateButton.BackColor = Color.LightGreen;
                activateButton.Text = "Activate Riddler";
                isRiddlerActive = false;
            }
        }

        public void initialize_riddle()
        {
            HebrewWord chosenWord;
            if (DEBUGME)
            {
                chosenWord = HebrewWord.wordsInGame[debug_word_index];
            }
            else
            {
                chosenWord = SuspenderLib.HebrewWord.getRandomHebrewWord(DEBUGME);
            }

            switch (chosenWord.riddle_type)
            {
                case 0:
                    rf = new RiddleOnlyLetter();
                    break;
                case 1:
                    rf = new RiddleWordFirst();
                    break;
                case 2:
                    rf = new RiddleFirstLetter();
                    break;
                case 3:
                    rf = new RiddleLastLetter();
                    break;
            }
            rf.extraInitializations();
            rf.chosenWord = chosenWord;
            rf.setup_riddle();
        }

        public void activateRiddle()
        {
            activateTimer.Stop();
            try
            {
                Logger.Log("RiddleController.Form1.activateRiddle()");
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);

                if (!DEBUGME) Processer.SuspendChrome();

                Logger.Log("RiddleController.Form1.activateRiddle()-before rf.show()");
                rf.Show();
                Logger.Log("RiddleController.Form1.activateRiddle()-after rf.show()");
                rf.display_riddle();

                Logger.Log("After Run");
                if (!DEBUGME) Processer.SuspendChrome(true);


                if (!DEBUGME) System.Threading.Thread.Sleep(105000);
                else System.Threading.Thread.Sleep(2000);
                if (DEBUGME)
                {
                    debug_word_index++;
                    if (debug_word_index == HebrewWord.wordsInGame.Count) debug_word_index = 0;
                }

            }
            catch (Exception exc)
            {
                Logger.Log("Exception on RiddleController.activateTimer_Tick");
                Logger.Log("Exception=" + exc.Message);
            }
        }
        private void activateTimer_Tick(object sender, EventArgs e)
        {
            timeToRiddle--;
            timerToRiddleLabel.Text = timeToRiddle.ToString();
            if (timeToRiddle == 0) activateRiddle();
        }

    }
}
