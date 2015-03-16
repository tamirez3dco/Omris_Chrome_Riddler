namespace HAMENAJES
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delayScrollBarLabel = new System.Windows.Forms.Label();
            this.delayChooserTrackBar = new System.Windows.Forms.TrackBar();
            this.activateButton = new System.Windows.Forms.Button();
            this.programToHaltTextBox = new System.Windows.Forms.TextBox();
            this.ProgramToHaltLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numMesichimComboBox = new System.Windows.Forms.ComboBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox0 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.wordsDataGridView = new System.Windows.Forms.DataGridView();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Sound = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.activationStatusLabel = new System.Windows.Forms.Label();
            this.activateTimer = new System.Windows.Forms.Timer(this.components);
            this.label3VisibiltyTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayChooserTrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 418);
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
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Activate";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "180 sec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "10 sec";
            // 
            // delayScrollBarLabel
            // 
            this.delayScrollBarLabel.AutoSize = true;
            this.delayScrollBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.delayScrollBarLabel.Location = new System.Drawing.Point(30, 240);
            this.delayScrollBarLabel.Name = "delayScrollBarLabel";
            this.delayScrollBarLabel.Size = new System.Drawing.Size(205, 24);
            this.delayScrollBarLabel.TabIndex = 5;
            this.delayScrollBarLabel.Text = "Time Between Riddles:";
            // 
            // delayChooserTrackBar
            // 
            this.delayChooserTrackBar.Location = new System.Drawing.Point(28, 270);
            this.delayChooserTrackBar.Maximum = 180;
            this.delayChooserTrackBar.Minimum = 10;
            this.delayChooserTrackBar.Name = "delayChooserTrackBar";
            this.delayChooserTrackBar.Size = new System.Drawing.Size(395, 45);
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
            this.activateButton.Location = new System.Drawing.Point(154, 124);
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
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.numMesichimComboBox);
            this.tabPage2.Controls.Add(this.checkBox6);
            this.tabPage2.Controls.Add(this.checkBox5);
            this.tabPage2.Controls.Add(this.checkBox4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.checkBox3);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.checkBox0);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ChooseRiddles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numMesichimComboBox
            // 
            this.numMesichimComboBox.FormattingEnabled = true;
            this.numMesichimComboBox.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.numMesichimComboBox.Location = new System.Drawing.Point(245, 222);
            this.numMesichimComboBox.Name = "numMesichimComboBox";
            this.numMesichimComboBox.Size = new System.Drawing.Size(97, 21);
            this.numMesichimComboBox.TabIndex = 8;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox6.Location = new System.Drawing.Point(60, 217);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(181, 33);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.Text = "Hebrew Read";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox5.Location = new System.Drawing.Point(60, 178);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(181, 33);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Hebrew FULL";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox4.Location = new System.Drawing.Point(60, 270);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(254, 33);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "English Single Letter";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(56, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(370, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "At least one riddle type must be checked !!!";
            this.label3.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox3.Location = new System.Drawing.Point(60, 141);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(234, 33);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Hebrew Last Letter";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox2.Location = new System.Drawing.Point(60, 102);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(237, 33);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Hebrew First Letter";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox1.Location = new System.Drawing.Point(60, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(243, 33);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Hebrew Word Copy";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox0
            // 
            this.checkBox0.AutoSize = true;
            this.checkBox0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBox0.Location = new System.Drawing.Point(60, 24);
            this.checkBox0.Name = "checkBox0";
            this.checkBox0.Size = new System.Drawing.Size(259, 33);
            this.checkBox0.TabIndex = 0;
            this.checkBox0.Text = "Hebrew Single Letter";
            this.checkBox0.UseVisualStyleBackColor = true;
            this.checkBox0.CheckedChanged += new System.EventHandler(this.checkBox0_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.wordsDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(476, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Riddles";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // wordsDataGridView
            // 
            this.wordsDataGridView.AllowUserToAddRows = false;
            this.wordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.word,
            this.Image,
            this.Sound,
            this.Active});
            this.wordsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.wordsDataGridView.Name = "wordsDataGridView";
            this.wordsDataGridView.RowHeadersVisible = false;
            this.wordsDataGridView.Size = new System.Drawing.Size(470, 386);
            this.wordsDataGridView.TabIndex = 0;
            this.wordsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.wordsDataGridView_CellContentClick);
            // 
            // word
            // 
            this.word.HeaderText = "Word";
            this.word.Name = "word";
            this.word.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Image.Width = 190;
            // 
            // Sound
            // 
            this.Sound.HeaderText = "Sound";
            this.Sound.Name = "Sound";
            this.Sound.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sound.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Sound.Text = "update sound";
            this.Sound.ToolTipText = "The voice sounded at riddle";
            this.Sound.UseColumnTextForButtonValue = true;
            this.Sound.Width = 70;
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.Width = 40;
            // 
            // activationStatusLabel
            // 
            this.activationStatusLabel.AutoSize = true;
            this.activationStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.activationStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.activationStatusLabel.Location = new System.Drawing.Point(162, 2);
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
            // label3VisibiltyTimer
            // 
            this.label3VisibiltyTimer.Interval = 250;
            this.label3VisibiltyTimer.Tick += new System.EventHandler(this.label3VisibiltyTimer_Tick);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Sound";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "update sound";
            this.dataGridViewButtonColumn1.ToolTipText = "The voice sounded at riddle";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Num of optional answers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 452);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.activationStatusLabel);
            this.MaximumSize = new System.Drawing.Size(500, 1000);
            this.MinimumSize = new System.Drawing.Size(500, 490);
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
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer label3VisibiltyTimer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView wordsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewButtonColumn Sound;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ComboBox numMesichimComboBox;
        private System.Windows.Forms.Label label4;
    }
}

