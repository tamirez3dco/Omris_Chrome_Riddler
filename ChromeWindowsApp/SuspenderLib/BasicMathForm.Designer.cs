namespace SuspenderLib
{
    partial class BasicMathForm
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
            this.riddleLabel = new System.Windows.Forms.Label();
            this.equatorLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timerCircle1 = new SuspenderLib.TimerCircle();
            this.SuspendLayout();
            // 
            // fuckupTimer
            // 
            this.fuckupTimer.Interval = 5000;
            this.fuckupTimer.Tick += new System.EventHandler(this.fuckupTimer_Tick_1);
            // 
            // riddleLabel
            // 
            this.riddleLabel.AutoSize = true;
            this.riddleLabel.BackColor = System.Drawing.Color.White;
            this.riddleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.riddleLabel.Location = new System.Drawing.Point(195, 108);
            this.riddleLabel.Name = "riddleLabel";
            this.riddleLabel.Size = new System.Drawing.Size(126, 46);
            this.riddleLabel.TabIndex = 0;
            this.riddleLabel.Text = "label1";
            this.riddleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // equatorLabel
            // 
            this.equatorLabel.AutoSize = true;
            this.equatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.equatorLabel.Location = new System.Drawing.Point(317, 108);
            this.equatorLabel.Name = "equatorLabel";
            this.equatorLabel.Size = new System.Drawing.Size(76, 46);
            this.equatorLabel.TabIndex = 3;
            this.equatorLabel.Text = "= ?";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(53, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button2.Location = new System.Drawing.Point(168, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 56);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button3.Location = new System.Drawing.Point(283, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 56);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button4.Location = new System.Drawing.Point(398, 237);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 56);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // timerCircle1
            // 
            this.timerCircle1.ForeColor = System.Drawing.Color.Red;
            this.timerCircle1.Location = new System.Drawing.Point(183, 168);
            this.timerCircle1.Name = "timerCircle1";
            this.timerCircle1.Size = new System.Drawing.Size(150, 150);
            this.timerCircle1.TabIndex = 8;
            this.timerCircle1.Visible = false;
            this.timerCircle1.TimerFinished += new System.EventHandler(this.timerCircle1_TimerFinished);
            // 
            // BasicMathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 366);
            this.ControlBox = false;
            this.Controls.Add(this.timerCircle1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.equatorLabel);
            this.Controls.Add(this.riddleLabel);
            this.Name = "BasicMathForm";
            this.Text = "BasicMathForm";
            this.Load += new System.EventHandler(this.BasicMathForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label riddleLabel;
        private System.Windows.Forms.Label equatorLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private TimerCircle timerCircle1;
    }
}