namespace lab_part2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSearch = new Button();
            textBoxFileName = new TextBox();
            richTextBoxResults = new RichTextBox();
            SuspendLayout();
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(382, 37);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 0;
            buttonSearch.Text = "Шукати";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(38, 37);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(268, 23);
            textBoxFileName.TabIndex = 1;
            textBoxFileName.Text = "*.txt";
            // 
            // richTextBoxResults
            // 
            richTextBoxResults.Location = new Point(38, 82);
            richTextBoxResults.Name = "richTextBoxResults";
            richTextBoxResults.Size = new Size(1121, 546);
            richTextBoxResults.TabIndex = 4;
            richTextBoxResults.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 640);
            Controls.Add(richTextBoxResults);
            Controls.Add(textBoxFileName);
            Controls.Add(buttonSearch);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSearch;
        private TextBox textBoxFileName;
        private RichTextBox richTextBoxResults;
    }
}
