namespace RiddleApp
{
    partial class RiddleWordFirst
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
            this.riddleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.answerRichTextBox = new System.Windows.Forms.RichTextBox();
            this.soundStopperTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // riddleRichTextBox
            // 
            this.riddleRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.riddleRichTextBox.Location = new System.Drawing.Point(35, 36);
            this.riddleRichTextBox.Name = "riddleRichTextBox";
            this.riddleRichTextBox.ReadOnly = true;
            this.riddleRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.riddleRichTextBox.Size = new System.Drawing.Size(426, 141);
            this.riddleRichTextBox.TabIndex = 3;
            this.riddleRichTextBox.Text = "abc";
            this.riddleRichTextBox.Click += new System.EventHandler(this.riddleRichTextBox_Click);
            // 
            // answerRichTextBox
            // 
            this.answerRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.answerRichTextBox.Location = new System.Drawing.Point(35, 183);
            this.answerRichTextBox.Name = "answerRichTextBox";
            this.answerRichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.answerRichTextBox.Size = new System.Drawing.Size(426, 147);
            this.answerRichTextBox.TabIndex = 4;
            this.answerRichTextBox.Text = "";
            this.answerRichTextBox.SelectionChanged += new System.EventHandler(this.answerRichTextBox_SelectionChanged);
            this.answerRichTextBox.Click += new System.EventHandler(this.answerRichTextBox_Click);
            this.answerRichTextBox.TextChanged += new System.EventHandler(this.answerRichTextBox_TextChanged);
            // 
            // soundStopperTimer
            // 
            this.soundStopperTimer.Tick += new System.EventHandler(this.soundStopperTimer_Tick);
            // 
            // RiddleWordFirst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 356);
            this.Controls.Add(this.answerRichTextBox);
            this.Controls.Add(this.riddleRichTextBox);
            this.Name = "RiddleWordFirst";
            this.Text = "RiddleWordFirst";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RiddleWordFirst_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RiddleWordFirst_KeyPress);
            this.Controls.SetChildIndex(this.riddleImage, 0);
            this.Controls.SetChildIndex(this.riddleRichTextBox, 0);
            this.Controls.SetChildIndex(this.answerRichTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox riddleRichTextBox;
        private System.Windows.Forms.RichTextBox answerRichTextBox;
        private System.Windows.Forms.Timer soundStopperTimer;
    }
}