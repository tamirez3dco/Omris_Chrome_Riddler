namespace RiddleApp
{
    partial class RiddleOnlyLetter
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
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // riddleRichTextBox
            // 
            this.riddleRichTextBox.Font = new System.Drawing.Font("Miriam", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.riddleRichTextBox.Location = new System.Drawing.Point(103, 35);
            this.riddleRichTextBox.Size = new System.Drawing.Size(352, 200);
            // 
            // answerRichTextBox
            // 
            this.answerRichTextBox.Font = new System.Drawing.Font("Miriam", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.answerRichTextBox.Location = new System.Drawing.Point(103, 262);
            this.answerRichTextBox.Size = new System.Drawing.Size(352, 200);
            // 
            // riddleImage
            // 
            this.riddleImage.Location = new System.Drawing.Point(523, 35);
            this.riddleImage.Size = new System.Drawing.Size(43, 294);
            // 
            // RiddleOnlyLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 501);
            this.Name = "RiddleOnlyLetter";
            this.Text = "RiddleOnlyLetter";
            ((System.ComponentModel.ISupportInitialize)(this.riddleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}