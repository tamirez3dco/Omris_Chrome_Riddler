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
using System.Media;

namespace Riddler2
{
    using RiddleType = Int32;
    using System.Diagnostics;
    public partial class Form1 : Form
    {
        public SoundPlayer buzzer_player;
        public SoundPlayer gling_player;
        public SoundPlayer kolkavod_player;

        BasicRddleForm rf = null;
        public static bool isRiddlerActive = false;
        public static bool DEBUGME = false;
        int debug_word_index = 0;
        int timeToRiddle;

        public Form1()
        {
            InitializeComponent();
            loadValuesFromCfgFile();
            init_common_sounds();
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
                    sw.WriteLine("False");
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

                delayScrollBarLabel.Text += delayChooserTrackBar.Value.ToString() + " seconds."; 
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

            Processer.SuspendProcess(programToHaltTextBox.Text, true);
        }

        private void delayChooserTrackBar_ValueChanged(object sender, EventArgs e)
        {
            timeToRiddle = delayChooserTrackBar.Value;
            delayScrollBarLabel.Text = "Time between riddles : " + delayChooserTrackBar.Value.ToString() + " seconds.";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            activateTimer.Stop();
            if (!isRiddlerActive)
            {
                // activate riddler
                if (DEBUGME) timeToRiddle = 5;
                else timeToRiddle = delayChooserTrackBar.Value;

                // Flip buttons
                activateButton.BackColor = Color.IndianRed;
                activateButton.Text = "Stop Riddler";
                isRiddlerActive = true;

                activateTimer.Start();
            }
            else
            {
                activateButton.BackColor = Color.LightGreen;
                activateButton.Text = "Activate Riddler";
                isRiddlerActive = false;

                activationStatusLabel.Text = "Inaactive, no riddles expected.";
                activationStatusLabel.ForeColor = Color.Black;

                if ((rf != null) && (rf.Visible))
                {
                    rf.Visible = false;
                    SuspenderLib.Processer.SuspendProcess(programToHaltTextBox.Text, true);
                }
                
            }
        }
        public void init_common_sounds()
        {
            buzzer_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "buzzer_x.wav");
            buzzer_player.Load();
            gling_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "GLING.wav");
            gling_player.Load();
            kolkavod_player = new System.Media.SoundPlayer(Processer.mainResourcesPath + "kol_hakavod_lemushmush.wav");
            kolkavod_player.Load();
        }

        public void initialize_riddle()
        {
            HebrewWord chosenWord;
            if (DEBUGME)
            {
                chosenWord = HebrewWord.wordsInGame[0][debug_word_index];
            }
            else
            {
                List<RiddleType> allowed_types = new List<RiddleType>();

                if (checkBox0.Checked) allowed_types.Add(0);
                if (checkBox1.Checked) allowed_types.Add(1);
                if (checkBox2.Checked) allowed_types.Add(2);
                if (checkBox3.Checked) allowed_types.Add(3);

                RiddleType chosenType = allowed_types[new Random().Next(0, allowed_types.Count() - 1)];
                List<HebrewWord> chosenList = SuspenderLib.HebrewWord.wordsInGame[chosenType];

                chosenWord = chosenList[new Random().Next(0, chosenList.Count() - 1)];
            }

            switch (chosenWord.riddle_type)
            {
                case 0:
                    rf = new BasicRddleForm();
                    break;
                case 1:
                    rf = new HebrewWordForm();
                    break;
                case 2:
                    rf = new FirstLetterForm();
                    break;
                case 3:
                    rf = new LastLetterForm();
                    break;
            }
            rf.buzzer_player = buzzer_player;
            rf.gling_player = gling_player;
            rf.kolkavod_player = kolkavod_player;
            rf.init_form_by_riddle_word(chosenWord);
            rf.load_riddle_sounds_into_dict();

        }

        private void activateTimer_Tick(object sender, EventArgs e)
        {
            timeToRiddle--;

            activationStatusLabel.Text = "Active, Next Riddle in " + timeToRiddle.ToString() + " seconds.";
            activationStatusLabel.ForeColor = Color.Red;

            if (timeToRiddle == 0)
            {
                SuspenderLib.Processer.SuspendProcess(programToHaltTextBox.Text);

                activateTimer.Stop();

                initialize_riddle();

                rf.FormClosed += rf_FormClosed;
                rf.Show();

                activationStatusLabel.Text = "Active - Riddle is Showing !!!";
                activationStatusLabel.ForeColor = Color.Blue;
            
            }
        }

        void rf_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Release frozen app...
            SuspenderLib.Processer.SuspendProcess(programToHaltTextBox.Text, true);

            if (DEBUGME) debug_word_index++;
            //initialize_riddle();
            // reinint timers
            if (DEBUGME) timeToRiddle = 5;
            else timeToRiddle = delayChooserTrackBar.Value;


            activateTimer.Start();

            activationStatusLabel.Text = "Active - Riddle is Showing !!!";
            activationStatusLabel.ForeColor = Color.Blue;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcesses();
            List<String> processNames = new List<string>();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (!processNames.Contains(process.ProcessName)) processNames.Add(process.ProcessName);
                }
            }

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(processNames.ToArray());

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            programToHaltTextBox.Text = (String)comboBox1.SelectedItem;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select Program to Halt (from Existing)");
            comboBox1.SelectedItem = "Select Program to Halt (from Existing)";
            programToHaltTextBox.Focus();
            programToHaltTextBox.DeselectAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Select Program to Halt (from Existing)";
        }


    }
}
