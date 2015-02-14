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

namespace HAMENAJES
{
    using RiddleType = Int32;
    using System.Diagnostics;
    using System.Windows.Forms.VisualStyles;
    public partial class Form1 : Form
    {
        public SoundPlayer buzzer_player;
        public SoundPlayer gling_player;
        public SoundPlayer kolkavod_player;
        private Random randomer = new Random();

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
            Logger.LoggerFileLocation = Processer.mainDataPath;
            String cfgFilePath = Processer.mainDataPath + Path.DirectorySeparatorChar + "cfgFile.txt";
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
                checkBox4.Checked = bool.Parse(sr.ReadLine());

                delayScrollBarLabel.Text = "Time between riddles : " + delayChooserTrackBar.Value.ToString() + " seconds.";
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            String cfgFilePath = Processer.mainDataPath + Path.DirectorySeparatorChar + "cfgFile.txt";
            using (StreamWriter sw = new StreamWriter(cfgFilePath))
            {
                sw.WriteLine(programToHaltTextBox.Text);
                sw.WriteLine(delayChooserTrackBar.Value.ToString());
                sw.WriteLine(checkBox0.Checked);
                sw.WriteLine(checkBox1.Checked);
                sw.WriteLine(checkBox2.Checked);
                sw.WriteLine(checkBox3.Checked);
                sw.WriteLine(checkBox4.Checked);
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
                if (DEBUGME) timeToRiddle = 2;
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
            List<RiddleType> allowed_types = new List<RiddleType>();

            if (checkBox0.Checked) allowed_types.Add(0);
            if (checkBox1.Checked) allowed_types.Add(1);
            if (checkBox2.Checked) allowed_types.Add(2);
            if (checkBox3.Checked) allowed_types.Add(3);
            if (checkBox4.Checked) allowed_types.Add(4);

            RiddleType chosenType = allowed_types[randomer.Next(0, allowed_types.Count())];
            if (DEBUGME)
            {
                chosenType = allowed_types[0];
            }

            if (chosenType == 0) // a "single letter" hebrew riddle
            {
                HebrewLetter chosenLetter = HebrewLetter.hebrewLetters[randomer.Next(0, HebrewLetter.hebrewLetters.Count())];
                if (DEBUGME) chosenLetter = HebrewLetter.hebrewLetters[debug_word_index];
                chosenWord = make_word_out_of_letter(chosenLetter);
            }
            else if (chosenType == 4) // a "single letter" hebrew riddle
            {
                // choose an english letter by random
                int num = randomer.Next(0, 26); // Zero to 25
                char letter = (char)('a' + num);
                chosenWord = new HebrewWord(letter.ToString().ToUpper() , letter.ToString(), null,4);

            }
            else
            {
                List<HebrewWord> chosenList = HebrewWord.wordsInGame[chosenType];
                chosenWord = chosenList[randomer.Next(0, chosenList.Count())];
                if (DEBUGME)  chosenWord = chosenList[debug_word_index];
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
                case 4:
                    rf = new EnglishSingleLetterForm();
                    break;
            }
            rf.buzzer_player = buzzer_player;
            rf.gling_player = gling_player;
            rf.kolkavod_player = kolkavod_player;
            rf.init_form_by_riddle_word(chosenWord);
            rf.load_riddle_sounds_into_dict();

        }

        private HebrewWord make_word_out_of_letter(HebrewLetter letter)
        {
            return new HebrewWord(letter.english_char, letter.filename, null,0);
        }

        private void activateTimer_Tick(object sender, EventArgs e)
        {
            timeToRiddle--;

            activationStatusLabel.Text = "Active, Next Riddle in " + timeToRiddle.ToString() + " seconds.";
            activationStatusLabel.ForeColor = Color.Red;

            if (timeToRiddle == 0)
            {
                programToHaltTextBox.ReadOnly = true;
                comboBox1.Enabled = false;

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

            programToHaltTextBox.ReadOnly = false;
            comboBox1.Enabled = true;

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
                Logger.Log("Riddler2.Form1.comboBox1_DropDown : Found process " + process.ToString());
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.ProcessName.StartsWith(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)) continue;
                    Logger.Log("Riddler2.Form1.comboBox1_DropDown : Trying to add " + process.ToString());
                    if (!processNames.Contains(process.ProcessName)) processNames.Add(process.ProcessName);
                }
                else
                {
                    Logger.Log("Riddler2.Form1.comboBox1_DropDown : process " + process.ToString() + " has null or empty process.MainWindowTitle");
                }
            }

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(processNames.ToArray());

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            String newProgramToHalt = (String)comboBox1.SelectedItem;
            if (newProgramToHalt != null)
            {
                programToHaltTextBox.Text = (String)comboBox1.SelectedItem;
                programToHaltTextBox.Focus();
                programToHaltTextBox.DeselectAll();
            }
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select Program to Halt (from Existing)");
            comboBox1.SelectedItem = "Select Program to Halt (from Existing)";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            if (DEBUGME) this.Text += " -- DEBUG VERSION!!!";
            comboBox1.SelectedText = "Select Program to Halt (from Existing)";
            load_dgview_from_words();
            //wordsDataGridView.DataSource = HebrewWord.wordsDB;
        }

        public void load_dgview_from_words()
        {
            foreach (HebrewWord word in HebrewWord.wordsDB)
            {

                DataGridViewTamirRow newRow = new DataGridViewTamirRow();
                newRow.rowWord = word;
                String hebrewWord = word.getUnicodeWord();
                DataGridViewTextBoxCell wordCell = new DataGridViewTextBoxCell();
                wordCell.Value = hebrewWord;
                wordCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                newRow.Cells.Add(wordCell);

                Image image = null;
                String imagePath = Processer.mainResourcesPath + @"words_sounds\" + word.filename + ".jpg";

                if (File.Exists(imagePath))
                {
                    try
                    {
                        image = HebrewWordForm.LoadBitmap(imagePath);
                    }
                    catch (Exception e)
                    {

                    }
                }
                else
                {
                }

                DataGridViewImageCell imageCell = new DataGridViewImageCell();
                imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                imageCell.Value = image;
                newRow.Cells.Add(imageCell);

                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                buttonCell.UseColumnTextForButtonValue = false;
                
                newRow.Height = 100;

                wordsDataGridView.Rows.Add(newRow);
            }
            wordsDataGridView.AllowUserToResizeRows = false;
        }

        private void checkBox0_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = checkBox0;
            if (chk.Checked) label3.Visible = false;
            else if (!check_if_one_riddle_is_checked())
            {
                label3VisibiltyTimer.Start();
                chk.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = checkBox1;
            if (chk.Checked) label3.Visible = false;
            else if (!check_if_one_riddle_is_checked())
            {
                label3VisibiltyTimer.Start();
                chk.Checked = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = checkBox2;
            if (chk.Checked) label3.Visible = false;
            else if (!check_if_one_riddle_is_checked())
            {
                label3VisibiltyTimer.Start();
                chk.Checked = true;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = checkBox3;
            if (chk.Checked) label3.Visible = false;
            else if (!check_if_one_riddle_is_checked())
            {
                label3VisibiltyTimer.Start();
                chk.Checked = true;
            }

        }

        private bool check_if_one_riddle_is_checked()
        {
            if (checkBox0.Checked) return true;
            if (checkBox1.Checked) return true;
            if (checkBox2.Checked) return true;
            if (checkBox3.Checked) return true;
            if (checkBox4.Checked) return true;
            return false;
        }

        private void label3VisibiltyTimer_Tick(object sender, EventArgs e)
        {
            label3VisibiltyTimer.Stop();
            label3.Visible = true;
        }

        private void wordsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String name = this.wordsDataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewTamirRow row = (DataGridViewTamirRow)(wordsDataGridView.Rows[e.RowIndex]);
            Debug.WriteLine("walla, columnname =" + name + ", word=" + row.rowWord.getUnicodeWord());

            UploaderForm upform = new UploaderForm();
            upform.init_form_by_riddle_word(row.rowWord);
            upform.load_riddle_sounds_into_dict();

            upform.ShowDialog();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = checkBox4;
            if (chk.Checked) label3.Visible = false;
            else if (!check_if_one_riddle_is_checked())
            {
                label3VisibiltyTimer.Start();
                chk.Checked = true;
            }

        }

    }


    public class DataGridViewTamirRow : DataGridViewRow
    {
        public HebrewWord rowWord;
    }
}
