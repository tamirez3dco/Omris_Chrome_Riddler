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

        public override void do_whatever_on_show()
        {
            try
            {
                base.do_whatever_on_show();
                pictureBox1.Image = new Bitmap(Processer.mainResourcesPath + @"words_sounds\" + riddleWord.filename + ".jpg");
            }
            catch (Exception e)
            {
            }
        }

        private void HebrewWordForm_Load(object sender, EventArgs e)
        {
            do_whatever_on_show();
        }
    }
}
