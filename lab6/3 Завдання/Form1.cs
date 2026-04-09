using System;
using System.IO;
using System.Windows.Forms;

namespace lab_part3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Прив'язка подій
            listBoxContent.DoubleClick += new EventHandler(listBoxContent_DoubleClick);
            listBoxContent.SelectedIndexChanged += new EventHandler(listBoxContent_SelectedIndexChanged);
        }

        // --- Заглушки для Дизайнера ---
        private void textBoxCurrentPath_TextChanged(object sender, EventArgs e) { }
        private void labelFileInfo_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        // ------------------------------

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    LoadDirectory(fbd.SelectedPath);
                }
            }
        }

        private void LoadDirectory(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists) return;

                textBoxCurrentPath.Text = path;
                listBoxContent.Items.Clear();

                if (dir.Parent != null)
                {
                    listBoxContent.Items.Add(".. [Вгору]");
                }

                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    listBoxContent.Items.Add("📁 " + subDir.Name);
                }

                foreach (FileInfo file in dir.GetFiles())
                {
                    listBoxContent.Items.Add("📄 " + file.Name);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Доступ до цієї папки заборонено.");
            }
        }

        private void listBoxContent_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxContent.SelectedItem == null) return;

            string selected = listBoxContent.SelectedItem.ToString();
            string currentPath = textBoxCurrentPath.Text;

            if (selected == ".. [Вгору]")
            {
                DirectoryInfo parent = Directory.GetParent(currentPath);
                if (parent != null) LoadDirectory(parent.FullName);
                return;
            }

            if (selected.StartsWith("📁 "))
            {
                string folderName = selected.Replace("📁 ", "");
                string newPath = Path.Combine(currentPath, folderName);
                LoadDirectory(newPath);
            }
            else if (selected.StartsWith("📄 "))
            {
                ShowFileInfo(selected, currentPath);
            }
        }

        private void listBoxContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxContent.SelectedItem == null) return;

            string selected = listBoxContent.SelectedItem.ToString();
            string currentPath = textBoxCurrentPath.Text;

            if (selected.StartsWith("📄 "))
            {
                ShowFileInfo(selected, currentPath);
            }
            else
            {
                labelFileInfo.Text = "Виберіть файл для перегляду інформації";
            }
        }

        private void ShowFileInfo(string selectedItem, string currentPath)
        {
            string fileName = selectedItem.Replace("📄 ", "");
            FileInfo file = new FileInfo(Path.Combine(currentPath, fileName));

            // Написано в один рядок, щоб уникнути помилки "Newline in constant"
            labelFileInfo.Text = "Файл: " + file.Name + "\nРозмір: " + (file.Length / 1024) + " KB\nСтворено: " + file.CreationTime.ToString("dd.MM.yyyy HH:mm");
        }
    }
}