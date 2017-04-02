namespace SuspenderLib
{
    partial class AbstractRiddleForm
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
            this.kol_kavod_Timer = new System.Windows.Forms.Timer(this.components);
            this.fuckupTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // kol_kavod_Timer
            // 
            this.kol_kavod_Timer.Interval = 1500;
            this.kol_kavod_Timer.Tick += this.kol_kavod_Timer_Tick;
            // 
            // AbstractRiddleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AbstractRiddleForm";
            this.Text = "AbstractRiddleForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer kol_kavod_Timer;
        public System.Windows.Forms.Timer fuckupTimer;
    }
}