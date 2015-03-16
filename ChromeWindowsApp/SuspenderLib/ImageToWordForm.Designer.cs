namespace SuspenderLib
{
    partial class ImageToWordForm
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
            this.display_Label = new System.Windows.Forms.Label();
            this.fuckupTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // display_richTextBox
            // 
            this.display_richTextBox.Location = new System.Drawing.Point(371, 44);
            this.display_richTextBox.Visible = false;
            // 
            // answer_richTextBox
            // 
            this.answer_richTextBox.Location = new System.Drawing.Point(371, 38);
            this.answer_richTextBox.Visible = false;
            // 
            // display_Label
            // 
            this.display_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.display_Label.Font = new System.Drawing.Font("Arial", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.display_Label.Location = new System.Drawing.Point(284, 26);
            this.display_Label.Name = "display_Label";
            this.display_Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.display_Label.Size = new System.Drawing.Size(463, 165);
            this.display_Label.TabIndex = 13;
            this.display_Label.Text = "label1";
            this.display_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fuckupTimer
            // 
            this.fuckupTimer.Interval = 10000;
            this.fuckupTimer.Tick += new System.EventHandler(this.fuckupTimer_Tick);
            // 
            // ImageToWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 474);
            this.Controls.Add(this.display_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(1050, 512);
            this.Name = "ImageToWordForm";
            this.Text = "ImageToWordForm";
            this.Load += new System.EventHandler(this.ImageToWordForm_Load);
            this.Controls.SetChildIndex(this.display_richTextBox, 0);
            this.Controls.SetChildIndex(this.answer_richTextBox, 0);
            this.Controls.SetChildIndex(this.display_Label, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label display_Label;
        private System.Windows.Forms.Timer fuckupTimer;
    }
}