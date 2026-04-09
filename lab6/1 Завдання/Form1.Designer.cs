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
            buttonOpen = new Button();
            treeView1 = new TreeView();
            SuspendLayout();
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(362, 346);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(124, 31);
            buttonOpen.TabIndex = 0;
            buttonOpen.Text = "Вибрати папку";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += buttonOpen_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(127, 54);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(552, 253);
            treeView1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeView1);
            Controls.Add(buttonOpen);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOpen;
        private TreeView treeView1;
    }
}
