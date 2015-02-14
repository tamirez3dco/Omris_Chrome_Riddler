namespace SuspenderLib
{
    partial class BasicRddleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.display_richTextBox = new System.Windows.Forms.RichTextBox();
            this.delay_first_sound_timer = new System.Windows.Forms.Timer(this.components);
            this.answer_richTextBox = new System.Windows.Forms.RichTextBox();
            this.letterStoppedTimer = new System.Windows.Forms.Timer(this.components);
            this.kol_kavod_Timer = new System.Windows.Forms.Timer(this.components);
            this.soundStopperTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // display_richTextBox
            // 
            this.display_richTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.display_richTextBox.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.display_richTextBox.Location = new System.Drawing.Point(78, 55);
            this.display_richTextBox.Name = "display_richTextBox";
            this.display_richTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.display_richTextBox.Size = new System.Drawing.Size(326, 147);
            this.display_richTextBox.TabIndex = 1;
            this.display_richTextBox.Text = "";
            this.display_richTextBox.Click += new System.EventHandler(this.display_richTextBox_Click);
            this.display_richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.display_richTextBox_KeyDown);
            this.display_richTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.display_richTextBox_KeyPress);
            // 
            // delay_first_sound_timer
            // 
            this.delay_first_sound_timer.Interval = 300;
            this.delay_first_sound_timer.Tick += new System.EventHandler(this.delay_first_sound_timer_Tick);
            // 
            // answer_richTextBox
            // 
            this.answer_richTextBox.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.answer_richTextBox.Location = new System.Drawing.Point(78, 250);
            this.answer_richTextBox.Name = "answer_richTextBox";
            this.answer_richTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.answer_richTextBox.Size = new System.Drawing.Size(326, 147);
            this.answer_richTextBox.TabIndex = 2;
            this.answer_richTextBox.Text = "";
            this.answer_richTextBox.Click += new System.EventHandler(this.answer_richTextBox_Click);
            this.answer_richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.answer_richTextBox_KeyDown);
            this.answer_richTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.answer_richTextBox_KeyPress);
            // 
            // letterStoppedTimer
            // 
            this.letterStoppedTimer.Tick += new System.EventHandler(this.letterStoppedTimer_Tick);
            // 
            // kol_kavod_Timer
            // 
            this.kol_kavod_Timer.Interval = 1500;
            this.kol_kavod_Timer.Tick += new System.EventHandler(this.kol_kavod_Timer_Tick);
            // 
            // soundStopperTimer
            // 
            this.soundStopperTimer.Tick += new System.EventHandler(this.soundStopperTimer_Tick);
            // 
            // BasicRddleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 474);
            this.ControlBox = false;
            this.Controls.Add(this.answer_richTextBox);
            this.Controls.Add(this.display_richTextBox);
            this.Location = new System.Drawing.Point(200, 200);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 512);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 512);
            this.Name = "BasicRddleForm";
            this.Text = "BasicRiddleForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BasicRiddleForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicRiddleForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BasicRiddlerForm_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasicRiddleForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer delay_first_sound_timer;
        private System.Windows.Forms.Timer kol_kavod_Timer;
        public System.Windows.Forms.RichTextBox display_richTextBox;
        public System.Windows.Forms.RichTextBox answer_richTextBox;
        public System.Windows.Forms.Timer letterStoppedTimer;
        private System.Windows.Forms.Timer soundStopperTimer;
    }
}