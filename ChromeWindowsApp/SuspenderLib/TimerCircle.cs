using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class TimerCircle : UserControl
    {
        public event EventHandler TimerFinished;
        int millisCounter;

        private static int DefaultMilliseconds = 2000;
        private int milliSeconds = DefaultMilliseconds;

        // next comes the magic
        bool ShouldSerializeMilliSeconds() { return MilliSeconds != DefaultMilliseconds; }
        public int MilliSeconds
        {
            get
            {
                return milliSeconds;
            }

            set
            {
                milliSeconds = value;
            }
        }

        public TimerCircle()
        {
            milliSeconds = 2000;
            InitializeComponent();
        }

        public void show()
        {
            this.Visible = true;
            millisCounter = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            millisCounter += timer1.Interval;
            //this.Refresh();
            Graphics g = this.CreateGraphics();
            float endAngle = 360 * ((float)millisCounter / MilliSeconds);
            g.FillPie(new SolidBrush(this.ForeColor), this.ClientRectangle, 0, endAngle);

            if (millisCounter >= milliSeconds)
            {
                timer1.Stop();
                this.TimerFinished(this, new EventArgs());
                this.Visible = false;
            }
        }

        private void TimerCircle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float endAngle = 360 * ((float)millisCounter / MilliSeconds);
            g.FillPie(new SolidBrush(this.ForeColor), this.ClientRectangle, 0, endAngle);
        }
    }
}
