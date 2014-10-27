namespace RiddleApp
{
    partial class RiddleForm
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
            this.riddleImage = new System.Windows.Forms.PictureBox();
            this.kol_kavod_Timer = new System.Windows.Forms.Timer(this.components);
            this.letterStoppedTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // riddleImage
            // 
            this.riddleImage.Location = new System.Drawing.Point(566, 36);
            this.riddleImage.Name = "riddleImage";
            this.riddleImage.Size = new System.Drawing.Size(390, 273);
            this.riddleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.riddleImage.TabIndex = 2;
            this.riddleImage.TabStop = false;
            // 
            // kol_kavod_Timer
            // 
            this.kol_kavod_Timer.Interval = 5000;
            this.kol_kavod_Timer.Tick += new System.EventHandler(this.kol_kavod_Timer_Tick);
            // 
            // letterStoppedTimer
            // 
            this.letterStoppedTimer.Tick += new System.EventHandler(this.letterStoppedTimer_Tick);
            // 
            // RiddleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 356);
            this.ControlBox = false;
            this.Controls.Add(this.riddleImage);
            this.KeyPreview = true;
            this.Name = "RiddleForm";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RiddleForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer kol_kavod_Timer;
        public System.Windows.Forms.PictureBox riddleImage;
        public System.Windows.Forms.Timer letterStoppedTimer;
    }
}

