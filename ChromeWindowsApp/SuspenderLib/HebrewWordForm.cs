using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class HebrewWordForm : BasicRddleForm
    {
        public HebrewWordForm()
        {
            InitializeComponent();
        }



        public override void init_form_by_riddle_word(HebrewWord riddleWord)
        {
            base.init_form_by_riddle_word(riddleWord);
            desired_alignment = HorizontalAlignment.Right;
        }

        public static Bitmap LoadBitmap(string path)
        {
            //Open file in read only mode
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //Get a binary reader for the file stream
            using (BinaryReader reader = new BinaryReader(stream))
            {
                //copy the content of the file into a memory stream
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                //make a new Bitmap object the owner of the MemoryStream
                return new Bitmap(memoryStream);
            }
        }


        public override void do_whatever_on_show()
        {
            try
            {
                base.do_whatever_on_show();
                pictureBox1.Image = LoadBitmap(Processer.mainResourcesPath + @"words_sounds\" + riddleWord.filename + ".jpg");
                make_sure_window_on_top();

            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                Logger.Log(e.StackTrace);

            }
        }

        private void HebrewWordForm_Load(object sender, EventArgs e)
        {
            do_whatever_on_show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            word_player.Play();
        }
    }
}
