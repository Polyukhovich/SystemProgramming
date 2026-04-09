using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            MobilePhone myPhone = new MobilePhone("Samsung Galaxy", 35000.50, 2024,
                new List<string> { "NFC", "5G", "OLED Екран" });

            AnalyzeWithReflection(myPhone);
        }

        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void AnalyzeWithReflection(object obj)
        {
            treeView1.Nodes.Clear();

            Type t = obj.GetType();

            TreeNode root = new TreeNode($"Клас: {t.Name}");
            treeView1.Nodes.Add(root);

            TreeNode propsNode = new TreeNode("Властивості (Properties)");
            foreach (PropertyInfo prop in t.GetProperties())
            {
                object val = prop.GetValue(obj);
                string valStr = val is List<string> list ? string.Join(", ", list) : val?.ToString();

                propsNode.Nodes.Add($"{prop.Name} ({prop.PropertyType.Name}) = {valStr}");
            }
            root.Nodes.Add(propsNode);

            TreeNode methodsNode = new TreeNode("Методи (Methods)");
            foreach (MethodInfo method in t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                ParameterInfo[] parameters = method.GetParameters();
                string paramStr = string.Join(", ", Array.ConvertAll(parameters, p => $"{p.ParameterType.Name} {p.Name}"));

                methodsNode.Nodes.Add($"{method.ReturnType.Name} {method.Name}({paramStr})");
            }
            root.Nodes.Add(methodsNode);

            TreeNode constrNode = new TreeNode("Конструктори (Constructors)");
            foreach (ConstructorInfo constructor in t.GetConstructors())
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                string paramStr = string.Join(", ", Array.ConvertAll(parameters, p => $"{p.ParameterType.Name} {p.Name}"));

                constrNode.Nodes.Add($"{t.Name}({paramStr})");
            }
            root.Nodes.Add(constrNode);

            treeView1.ExpandAll();
        }
    }
}