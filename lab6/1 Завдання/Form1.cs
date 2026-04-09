using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_part2 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            // Створюємо стандартне діалогове вікно вибору папки
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Виберіть папку для перегляду її структури";

                
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    treeView1.Nodes.Clear(); 

                    
                    DirectoryInfo rootDir = new DirectoryInfo(fbd.SelectedPath);

                    // Створюємо найперший (головний) вузол у нашому дереві
                    TreeNode rootNode = new TreeNode(rootDir.Name);
                    treeView1.Nodes.Add(rootNode);

                    // Запускаємо процес малювання всього, що є всередині
                    BuildTree(rootDir, rootNode);

                    // Розгортаємо головну папку одразу після завантаження
                    rootNode.Expand();
                }
            }
        }

       
        private void BuildTree(DirectoryInfo dirInfo, TreeNode node)
        {
            try
            {
                // 1. Отримуємо і додаємо всі файли з поточної папки 
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    node.Nodes.Add( file.Name);
                }

                // 2. Отримуємо всі підкаталоги (папки всередині папки)
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                   
                    TreeNode subNode = new TreeNode( subDir.Name);
                    node.Nodes.Add(subNode);

                    // Викликаємо цей самий метод для підпапки (Рекурсія!)
                    BuildTree(subDir, subNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Якщо це якась системна папка (наприклад, Windows), куди не можна заходити
                node.Nodes.Add("[Відмовлено в доступі]");
            }
        }
    }
}