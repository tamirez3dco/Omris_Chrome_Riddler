namespace Riddler2
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delayScrollBarLabel = new System.Windows.Forms.Label();
            this.delayChooserTrackBar = new System.Windows.Forms.TrackBar();
            this.activateButton = new System.Windows.Forms.Button();
            this.programToHaltTextBox = new System.Windows.Forms.TextBox();
            this.ProgramToHaltLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox0 = new System.Windows.Forms.CheckBox();
            this.activationStatusLabel = new System.Windows.Forms.Label();
            this.activateTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayChooserTrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.delayScrollBarLabel);
            this.tabPage1.Controls.Add(this.delayChooserTrackBar);
            this.tabPage1.Controls.Add(this.activateButton);
            this.tabPage1.Controls.Add(this.programToHaltTextBox);
            this.tabPage1.Controls.Add(this.ProgramToHaltLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Activate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "180 sec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "10 sec";
            // 
            // delayScrollBarLabel
            // 
            this.delayScrollBarLabel.AutoSize = true;
            this.delayScrollBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.delayScrollBarLabel.Location = new System.Drawing.Point(68, 240);
            this.delayScrollBarLabel.Name = "delayScrollBarLabel";
            this.delayScrollBarLabel.Size = new System.Drawing.Size(205, 24);
            this.delayScrollBarLabel.TabIndex = 5;
            this.delayScrollBarLabel.Text = "Time Between Riddles:";
            // 
            // delayChooserTrackBar
            // 
            this.delayChooserTrackBar.Location = new System.Drawing.Point(66, 270);
            this.delayChooserTrackBar.Maximum = 180;
            this.delayChooserTrackBar.Minimum = 10;
            this.delayChooserTrackBar.Name = "delayChooserTrackBar";
            this.delayChooserTrackBar.Size = new System.Drawing.Size(339, 45);
            this.delayChooserTrackBar.SmallChange = 10;
            this.delayChooserTrackBar.TabIndex = 4;
            this.delayChooserTrackBar.TickFrequency = 10;
            this.delayChooserTrackBar.Value = 10;
            this.delayChooserTrackBar.ValueChanged += new System.EventHandler(this.delayChooserTrackBar_ValueChanged);
            // 
            // activateButton
            // 
            this.activateButton.BackColor = System.Drawing.Color.LightGreen;
            this.activateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.activateButton.Location = new System.Drawing.Point(66, 121);
            this.activateButton.Name = "activateButton";
            this.activateButton.Size = new System.Drawing.Size(148, 82);
            this.activateButton.TabIndex = 2;
            this.activateButton.Text = "Activate Riddler";
            this.activateButton.UseVisualStyleBackColor = false;
            this.activateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // programToHaltTextBox
            // 
            this.programToHaltTextBox.BackColor = System.Drawing.Color.Yellow;
            this.programToHaltTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.programToHaltTextBox.Location = new System.Drawing.Point(192, 26);
            this.programToHaltTextBox.Name = "programToHaltTextBox";
            this.programToHaltTextBox.Size = new System.Drawing.Size(157, 35);
            this.programToHaltTextBox.TabIndex = 1;
            this.programToHaltTextBox.Text = "chrome.exe";
            // 
            // ProgramToHaltLabel
            // 
            this.ProgramToHaltLabel.AutoSize = true;
            this.ProgramToHaltLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ProgramToHaltLabel.Location = new System.Drawing.Point(6, 29);
            this.ProgramToHaltLabel.Name = "ProgramToHaltLabel";
            this.ProgramToHaltLabel.Size = new System.Drawing.Size(192, 29);
            this.ProgramToHaltLabel.TabIndex = 0;
            this.ProgramToHaltLabel.Text = "Program to Halt :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox3);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.checkBox0);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ChooseRiddles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox3.Location = new System.Drawing.Point(60, 176);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(234, 33);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Hebrew Last Letter";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox2.Location = new System.Drawing.Point(60, 137);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(237, 33);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Hebrew First Letter";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox1.Location = new System.Drawing.Point(60, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(243, 33);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Hebrew Word Copy";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox0
            // 
            this.checkBox0.AutoSize = true;
            this.checkBox0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox0.Location = new System.Drawing.Point(60, 59);
            this.checkBox0.Name = "checkBox0";
            this.checkBox0.Size = new System.Drawing.Size(259, 33);
            this.checkBox0.TabIndex = 0;
            this.checkBox0.Text = "Hebrew Single Letter";
            this.checkBox0.UseVisualStyleBackColor = true;
            // 
            // activationStatusLabel
            // 
            this.activationStatusLabel.AutoSize = true;
            this.activationStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.activationStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.activationStatusLabel.Location = new System.Drawing.Point(84, 18);
            this.activationStatusLabel.Name = "activationStatusLabel";
            this.activationStatusLabel.Size = new System.Drawing.Size(265, 24);
            this.activationStatusLabel.TabIndex = 8;
            this.activationStatusLabel.Text = "Inaactive, no riddles expected.";
            // 
            // activateTimer
            // 
            this.activateTimer.Interval = 1000;
            this.activateTimer.Tick += new System.EventHandler(this.activateTimer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Select Program to Halt (from Existing)"});
            this.comboBox1.Location = new System.Drawing.Point(154, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 452);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.activationStatusLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayChooserTrackBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TrackBar delayChooserTrackBar;
        private System.Windows.Forms.Button activateButton;
        private System.Windows.Forms.TextBox programToHaltTextBox;
        private System.Windows.Forms.Label ProgramToHaltLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label delayScrollBarLabel;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox0;
        private System.Windows.Forms.Timer activateTimer;
        private System.Windows.Forms.Label activationStatusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

