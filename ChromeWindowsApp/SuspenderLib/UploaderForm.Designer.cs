namespace SuspenderLib
{
    partial class UploaderForm
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
            this.updateImageButton = new System.Windows.Forms.Button();
            this.updateSoundButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.waveViewer1 = new NAudio.Gui.WaveViewer();
            this.progressLog1 = new NAudio.Utils.ProgressLog();
            this.startLine = new System.Windows.Forms.Panel();
            this.EndLine = new System.Windows.Forms.Panel();
            this.playCroptedButton = new System.Windows.Forms.Button();
            this.recordSoundButton = new System.Windows.Forms.Button();
            this.waveTimer = new System.Windows.Forms.Timer(this.components);
            this.wavePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // display_richTextBox
            // 
            this.display_richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.display_richTextBox_KeyDown);
            // 
            // answer_richTextBox
            // 
            this.answer_richTextBox.Visible = false;
            // 
            // updateImageButton
            // 
            this.updateImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.updateImageButton.Location = new System.Drawing.Point(254, 277);
            this.updateImageButton.Name = "updateImageButton";
            this.updateImageButton.Size = new System.Drawing.Size(121, 66);
            this.updateImageButton.TabIndex = 4;
            this.updateImageButton.Text = "Upload Image From File";
            this.updateImageButton.UseVisualStyleBackColor = true;
            this.updateImageButton.Click += new System.EventHandler(this.updateImageButton_Click);
            // 
            // updateSoundButton
            // 
            this.updateSoundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.updateSoundButton.Location = new System.Drawing.Point(399, 277);
            this.updateSoundButton.Name = "updateSoundButton";
            this.updateSoundButton.Size = new System.Drawing.Size(123, 66);
            this.updateSoundButton.TabIndex = 5;
            this.updateSoundButton.Text = "Upload Sound From File";
            this.updateSoundButton.UseVisualStyleBackColor = true;
            this.updateSoundButton.Click += new System.EventHandler(this.updateSoundButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 68);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save & Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Record Sound";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // waveViewer1
            // 
            this.waveViewer1.Location = new System.Drawing.Point(103, 172);
            this.waveViewer1.Name = "waveViewer1";
            this.waveViewer1.SamplesPerPixel = 128;
            this.waveViewer1.Size = new System.Drawing.Size(397, 99);
            this.waveViewer1.StartPosition = ((long)(0));
            this.waveViewer1.TabIndex = 8;
            this.waveViewer1.WaveStream = null;
            // 
            // progressLog1
            // 
            this.progressLog1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressLog1.Location = new System.Drawing.Point(208, 123);
            this.progressLog1.Name = "progressLog1";
            this.progressLog1.Padding = new System.Windows.Forms.Padding(1);
            this.progressLog1.Size = new System.Drawing.Size(250, 43);
            this.progressLog1.TabIndex = 9;
            // 
            // startLine
            // 
            this.startLine.BackColor = System.Drawing.Color.Red;
            this.startLine.Location = new System.Drawing.Point(103, 172);
            this.startLine.Name = "startLine";
            this.startLine.Size = new System.Drawing.Size(10, 98);
            this.startLine.TabIndex = 10;
            this.startLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startLine_MouseDown);
            this.startLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.startLine_MouseMove);
            // 
            // EndLine
            // 
            this.EndLine.BackColor = System.Drawing.Color.Blue;
            this.EndLine.Location = new System.Drawing.Point(491, 172);
            this.EndLine.Name = "EndLine";
            this.EndLine.Size = new System.Drawing.Size(10, 98);
            this.EndLine.TabIndex = 11;
            this.EndLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EndLine_MouseDown);
            this.EndLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EndLine_MouseMove);
            // 
            // playCroptedButton
            // 
            this.playCroptedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.playCroptedButton.Location = new System.Drawing.Point(103, 277);
            this.playCroptedButton.Name = "playCroptedButton";
            this.playCroptedButton.Size = new System.Drawing.Size(121, 66);
            this.playCroptedButton.TabIndex = 12;
            this.playCroptedButton.Text = "Play cropted";
            this.playCroptedButton.UseVisualStyleBackColor = true;
            this.playCroptedButton.Click += new System.EventHandler(this.playCroptedButton_Click);
            // 
            // recordSoundButton
            // 
            this.recordSoundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.recordSoundButton.Location = new System.Drawing.Point(548, 277);
            this.recordSoundButton.Name = "recordSoundButton";
            this.recordSoundButton.Size = new System.Drawing.Size(121, 66);
            this.recordSoundButton.TabIndex = 13;
            this.recordSoundButton.Text = "Record Sound";
            this.recordSoundButton.UseVisualStyleBackColor = true;
            this.recordSoundButton.Click += new System.EventHandler(this.recordSoundButton_Click);
            // 
            // waveTimer
            // 
            this.waveTimer.Tick += new System.EventHandler(this.waveTimer_Tick);
            // 
            // wavePanel
            // 
            this.wavePanel.BackColor = System.Drawing.Color.Yellow;
            this.wavePanel.Location = new System.Drawing.Point(103, 175);
            this.wavePanel.Name = "wavePanel";
            this.wavePanel.Size = new System.Drawing.Size(3, 98);
            this.wavePanel.TabIndex = 14;
            this.wavePanel.Visible = false;
            // 
            // UploaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 474);
            this.Controls.Add(this.wavePanel);
            this.Controls.Add(this.recordSoundButton);
            this.Controls.Add(this.playCroptedButton);
            this.Controls.Add(this.EndLine);
            this.Controls.Add(this.startLine);
            this.Controls.Add(this.progressLog1);
            this.Controls.Add(this.waveViewer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.updateSoundButton);
            this.Controls.Add(this.updateImageButton);
            this.Name = "UploaderForm";
            this.Text = "UploaderForm";
            this.Load += new System.EventHandler(this.UploaderForm_Load);
            this.Controls.SetChildIndex(this.display_richTextBox, 0);
            this.Controls.SetChildIndex(this.answer_richTextBox, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.updateImageButton, 0);
            this.Controls.SetChildIndex(this.updateSoundButton, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.waveViewer1, 0);
            this.Controls.SetChildIndex(this.progressLog1, 0);
            this.Controls.SetChildIndex(this.startLine, 0);
            this.Controls.SetChildIndex(this.EndLine, 0);
            this.Controls.SetChildIndex(this.playCroptedButton, 0);
            this.Controls.SetChildIndex(this.recordSoundButton, 0);
            this.Controls.SetChildIndex(this.wavePanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button updateImageButton;
        private System.Windows.Forms.Button updateSoundButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private NAudio.Gui.WaveViewer waveViewer1;
        private NAudio.Utils.ProgressLog progressLog1;
        private System.Windows.Forms.Panel startLine;
        private System.Windows.Forms.Panel EndLine;
        private System.Windows.Forms.Button playCroptedButton;
        private System.Windows.Forms.Button recordSoundButton;
        private System.Windows.Forms.Timer waveTimer;
        private System.Windows.Forms.Panel wavePanel;
    }
}