using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuspenderLib
{
    public partial class BasicMathForm : AbstractRiddleForm
    {
        public BasicMathForm(List<OPERATION> allowedOps)
        {
            InitializeComponent();
            op = allowedOps[r.Next(0, allowedOps.Count)];
        }

        int arg1, arg2, res;
        OPERATION op;
        public enum OPERATION
        {
            Add,
            SUB,
            MULT,
            DIV
        }

        private void fuckupTimer_Tick(object sender, EventArgs e)
        {
            fuckupTimer.Stop();
            this.BackColor = origBack;
            foreach (Button b in ansButtons)
            {
                b.Visible = true;
            }
            this.Refresh();
        }

        Color origBack;
        private void button_Click(object sender, EventArgs e)
        {
            Button bSender = (Button)sender;
            if (riddleAboutToClose) return;

            bool answerWasCorrect = int.Parse(bSender.Text) == res;
            if (answerWasCorrect)
            {
                gling_player.Play();
                play_kolkavod_and_set_close_timers();
                return;
            }
            else
            {
                origBack = this.BackColor;
                foreach (Button b in ansButtons)
                {
                    b.Visible = false;
                }
                this.BackColor = Color.Black;
                //fuckupTimer.Start();
                buzzer_player.Play();
                timerCircle1.show();
            }

        }

        Random r = Randomer.randomer;

        private void fuckupTimer_Tick_1(object sender, EventArgs e)
        {
            fuckupTimer.Stop();
            this.BackColor = origBack;
            foreach (Button b in ansButtons)
            {
                b.Visible = true;
            }
            this.Refresh();

        }

        private void timerCircle1_TimerFinished(object sender, EventArgs e)
        {
            timerCircle1.MilliSeconds = Math.Min(timerCircle1.MilliSeconds * 2, 10000);
            this.BackColor = origBack;
            foreach (Button b in ansButtons)
            {
                b.Visible = true;
            }
            this.Refresh();
        }

        Button[] ansButtons;
        private void BasicMathForm_Load(object sender, EventArgs e)
        {
            char op_c = ' ';
            List<int> allAnswers = new List<int>();
            switch (op)
            {
                case OPERATION.DIV:
                    res = r.Next(2, 10);
                    int mana = r.Next(2, 10);
                    if (res > 5)
                    {
                        mana = r.Next(2, 4);
                    }
                    arg1 = mana * res;
                    arg2 = mana;
                    op_c = '\u00F7';
                    allAnswers.Add(res);
                    while (allAnswers.Count < 4)
                    {
                        int mesiah = r.Next(2, 10);
                        if (allAnswers.Contains(mesiah)) continue;
                        allAnswers.Add(mesiah);
                    }                  
                    break;
                case OPERATION.MULT:
                    arg1 = r.Next(0, 11);
                    arg2 = r.Next(0, 10);
                    res = arg1 * arg2;
                    op_c = 'x';
                    allAnswers.Add(res);
                    while (allAnswers.Count < 4)
                    {
                        int mesiah = Math.Max(0, res + r.Next(-10, 10));
                        if (allAnswers.Contains(mesiah)) continue;
                        allAnswers.Add(mesiah);
                    }
                    break;
                case OPERATION.Add:
                    arg1 = r.Next(0, 30);
                    arg2 = r.Next(0, 30);
                    res = arg1 + arg2;
                    op_c = '+';
                    allAnswers.Add(res);
                    while (allAnswers.Count < 4)
                    {
                        int mesiah = Math.Max(0,res + r.Next(-4, 4));
                        if (allAnswers.Contains(mesiah)) continue;
                        allAnswers.Add(mesiah);
                    }
                    break;
                case OPERATION.SUB:
                    arg1 = r.Next(0, 30);
                    arg2 = r.Next(0, arg1+1);
                    res = arg1 - arg2;
                    op_c = '-';
                    allAnswers.Add(res);
                    while (allAnswers.Count < 4)
                    {
                        int mesiah = res + r.Next(-3, 3);
                        if (allAnswers.Contains(mesiah)) continue;
                        allAnswers.Add(mesiah);
                    }
                    break;
            }

            Button[] allButtons = { button1, button2, button3, button4 };
            ansButtons = allButtons;
            List<Button> ansButtonsList = new List<Button>(ansButtons);
            for (int i = 0; i < 4; i ++)
            {
                int mesiahIndex = r.Next(0, ansButtonsList.Count);
                ansButtonsList[mesiahIndex].Text = allAnswers[i].ToString();
                ansButtonsList.RemoveAt(mesiahIndex);
            }
            riddleLabel.Text = arg1.ToString() + " " + op_c + " " + arg2.ToString();
            riddleLabel.Left = equatorLabel.Left - 5 - riddleLabel.Width;
        }
    }
}
