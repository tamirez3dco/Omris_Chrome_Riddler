using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class AbstractRiddleForm : Form
    {
        public SoundPlayer buzzer_player;
        public SoundPlayer gling_player;
        public SoundPlayer kolkavod_player;

        public bool riddleAboutToClose = false;

        public void play_kolkavod_and_set_close_timers()
        {
            riddleAboutToClose = true;

            kolkavod_player.Play();
            kol_kavod_Timer.Start();
        }

        public void kol_kavod_Timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }


        public AbstractRiddleForm()
        {
            InitializeComponent();
        }

        public virtual void load_riddle_sounds_into_dict()
        {

        }
        public virtual void init_form_by_riddle_word(HebrewWord riddleWord)
        {
        }

    }
}
