using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuspenderLib;
using System.Threading;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.IO;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Processer.SuspendProcess("Chrome.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Processer.SuspendProcess("Chrome.exe",true);
        }

        System.Media.SoundPlayer my_player;
        private void button3_Click(object sender, EventArgs e)
        {
            my_player = new System.Media.SoundPlayer(@"C:\chrome\test3\Sounds\buzzer_x.wav");
            my_player.Load();

            Thread.Sleep(2000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            my_player.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SuspenderLib.Processer.GetChromesPlayingYouTube();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bool timerEnabled = annoyerTimer.Enabled;
            if (timerEnabled)
            {
                annoyerTimer.Stop();
            }
            annoyerTimer.Interval = (int)(numericUpDown1.Value * 1000);
            if (timerEnabled)
            {
                annoyerTimer.Start();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer serlizer = new JavaScriptSerializer();
            String content = File.ReadAllText(SuspenderLib.Processer.listPath);
            Object o = serlizer.DeserializeObject(content);
            List<HebrewWord> words = serlizer.Deserialize<List<HebrewWord>>(content);
            Object[] o_arr = (Object[])o;
            Dictionary<String, Object> dicto = (Dictionary<String, Object>)(o_arr[0]);
            Logger.Log("wlla");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Debug.WriteLine("e.value=" + e.
            e.Handled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Select(0, 1);
            richTextBox1.SelectionBackColor = Color.Red;
            timer1.Start();
        }

        int color_index = 0;
        Color[] colors = { Color.Red, Color.White, Color.Black };
        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.Select(0, 1);
            richTextBox1.SelectionColor = colors[color_index];
            color_index = (color_index + 1) % colors.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button8.PerformClick();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Processer.SuspendProcess2("chrome");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Processer.ResumeChromes();
        }

        private void button11_Click(object sender, EventArgs e)
        {
        }
    }
}
