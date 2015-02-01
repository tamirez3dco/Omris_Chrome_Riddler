namespace RiddlerController
{
    partial class RiddleFirstLetter
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
            this.answerRichTextBox = new System.Windows.Forms.RichTextBox();
            this.bleepTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // riddleImage
            // 
            this.riddleImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.riddleImage_MouseClick);
            // 
            // answerRichTextBox
            // 
            this.answerRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.answerRichTextBox.Location = new System.Drawing.Point(62, 89);
            this.answerRichTextBox.Name = "answerRichTextBox";
            this.answerRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.answerRichTextBox.Size = new System.Drawing.Size(426, 147);
            this.answerRichTextBox.TabIndex = 5;
            this.answerRichTextBox.Text = "";
            this.answerRichTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.answerRichTextBox_MouseClick);
            // 
            // bleepTimer
            // 
            this.bleepTimer.Interval = 400;
            this.bleepTimer.Tick += new System.EventHandler(this.bleepTimer_Tick);
            // 
            // RiddleFirstLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1103, 356);
            this.Controls.Add(this.answerRichTextBox);
            this.Name = "RiddleFirstLetter";
            this.Text = "RiddleFirstLetter";
            this.Load += new System.EventHandler(this.RiddleFirstLetter_Load);
            this.Controls.SetChildIndex(this.riddleImage, 0);
            this.Controls.SetChildIndex(this.answerRichTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer bleepTimer;
        public System.Windows.Forms.RichTextBox answerRichTextBox;

    }
}