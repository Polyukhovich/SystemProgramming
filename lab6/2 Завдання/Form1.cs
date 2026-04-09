using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace lab_part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            richTextBoxResults.Font = new Font("Consolas", 10);

            // Налаштування "прозорої" підказки (Placeholder)
            textBoxFileName.Text = "*.txt";
            textBoxFileName.ForeColor = Color.Gray;

            // Прив'язуємо події для зникнення/появи тексту
            textBoxFileName.Enter += RemoveText;
            textBoxFileName.Leave += AddText;
        }

        // Коли користувач клікає на поле — текст зникає, колір стає чорним
        private void RemoveText(object sender, EventArgs e)
        {
            if (textBoxFileName.Text == "*.txt")
            {
                textBoxFileName.Text = "";
                textBoxFileName.ForeColor = Color.Black;
            }
        }

        // Коли користувач забирає курсор, а поле пусте — повертаємо сіру підказку
        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFileName.Text))
            {
                textBoxFileName.Text = "*.txt";
                textBoxFileName.ForeColor = Color.Gray;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string fileName = textBoxFileName.Text;

            if (string.IsNullOrWhiteSpace(fileName) || fileName == "*.txt")
            {
                MessageBox.Show("Будь ласка, введіть назву файлу!");
                return;
            }

            richTextBoxResults.Clear();
            richTextBoxResults.AppendText($"🔍 ГЛОБАЛЬНИЙ ПОШУК: '{fileName}'\n");
            richTextBoxResults.AppendText(new string('=', 65) + "\n\n");

            // Отримуємо список всіх логічних дисків 
            string[] drives = Directory.GetLogicalDrives();
            int totalFound = 0;

            foreach (string drive in drives)
            {
                richTextBoxResults.AppendText($"[ Сканування диска {drive} ]\n");
                Application.DoEvents();

                DirectoryInfo rootDir = new DirectoryInfo(drive);
                totalFound += SafeSearch(rootDir, fileName);
            }

            richTextBoxResults.AppendText($"\n✅ ГОТОВО! Знайдено файлів: {totalFound}\n");
        }

        private int SafeSearch(DirectoryInfo dir, string pattern)
        {
            int count = 0;
            try
            {
                FileInfo[] files = dir.GetFiles(pattern);

                foreach (FileInfo f in files)
                {
                    richTextBoxResults.AppendText($" 📄 {f.Name}\n");
                    richTextBoxResults.AppendText($"    ├─ Папка:    {f.DirectoryName}\n");
                    richTextBoxResults.AppendText($"    ├─ Розмір:   {FormatSize(f.Length)}\n");
                    richTextBoxResults.AppendText($"    ├─ Створено: {f.CreationTime:dd.MM.yyyy HH:mm}\n");
                    richTextBoxResults.AppendText($"    └─ Повний шлях: {f.FullName}\n");
                    richTextBoxResults.AppendText(new string('─', 65) + "\n\n");

                    count++;
                    Application.DoEvents();
                }

                DirectoryInfo[] subDirs = dir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    count += SafeSearch(subDir, pattern);
                }
            }
            catch (UnauthorizedAccessException) { /* Пропускаємо системні папки */ }
            catch (Exception) { /* Ігноруємо інші помилки */ }

            return count;
        }

        private string FormatSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1048576) return $"{(bytes / 1024.0):F1} KB";
            return $"{(bytes / 1048576.0):F2} MB";
        }
    }
}