namespace lab_part3
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
            buttonOpen = new Button();
            textBoxCurrentPath = new TextBox();
            listBoxContent = new ListBox();
            labelFileInfo = new Label();
            SuspendLayout();
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(89, 24);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(250, 23);
            buttonOpen.TabIndex = 0;
            buttonOpen.Text = "Вибрати початковий диск/папку";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += buttonOpen_Click;
            // 
            // textBoxCurrentPath
            // 
            textBoxCurrentPath.Location = new Point(89, 64);
            textBoxCurrentPath.Name = "textBoxCurrentPath";
            textBoxCurrentPath.Size = new Size(551, 23);
            textBoxCurrentPath.TabIndex = 1;
            textBoxCurrentPath.TextChanged += textBoxCurrentPath_TextChanged;
            // 
            // listBoxContent
            // 
            listBoxContent.FormattingEnabled = true;
            listBoxContent.Location = new Point(89, 142);
            listBoxContent.Name = "listBoxContent";
            listBoxContent.Size = new Size(347, 214);
            listBoxContent.TabIndex = 2;
            listBoxContent.SelectedIndexChanged += listBoxContent_SelectedIndexChanged;
            // 
            // labelFileInfo
            // 
            labelFileInfo.AutoSize = true;
            labelFileInfo.Location = new Point(511, 142);
            labelFileInfo.Name = "labelFileInfo";
            labelFileInfo.Size = new Size(38, 15);
            labelFileInfo.TabIndex = 3;
            labelFileInfo.Text = "label1";
            labelFileInfo.Click += labelFileInfo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelFileInfo);
            Controls.Add(listBoxContent);
            Controls.Add(textBoxCurrentPath);
            Controls.Add(buttonOpen);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOpen;
        private TextBox textBoxCurrentPath;
        private ListBox listBoxContent;
        private Label labelFileInfo;
    }
}
