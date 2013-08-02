using LengthConsoleLab;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LengthCaculate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        private string inputFile;
        private Caculate caculate;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            if (File.Exists(inputFile))
                ofd.FileName = inputFile;
            ofd.Title = "请选择好您的输入文件";
            bool? result = ofd.ShowDialog(this);
            if (result != null && result.Value)
            {
                tbFile.Text = ofd.FileName;
            }
        }

        private void btnCaculate_Click(object sender, RoutedEventArgs e)
        {
            inputFile = tbFile.Text;
            if (string.IsNullOrWhiteSpace(inputFile))
            {
                MessageBox.Show("输入文件没有设置好");
                return;
            }
            if (!File.Exists(inputFile))
            {
                MessageBox.Show("输入文件不存在");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "请设置好您要输出的文件";
            sfd.FileName = System.IO.Path.Combine(path, "output.txt");
            sfd.Filter = "*.txt|*.txt";
            bool? result = sfd.ShowDialog();
            if (result != null && result.Value)
            {
                try
                {
                    string[] inputs = File.ReadAllLines(inputFile);
                    string[] outputs = caculate.Output(inputs);
                    File.WriteAllLines(sfd.FileName, outputs);
                    MessageBox.Show("计算完毕");
                    OpenFileInDirectory(sfd.FileName, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Window_Initialized_1(object sender, EventArgs e)
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
            inputFile = System.IO.Path.Combine(path, "input.txt");
            if (File.Exists(inputFile))
                tbFile.Text = inputFile;
            tbFile.IsReadOnly = true;
            caculate = new Caculate();
        }

        public static void OpenFileInDirectory(string filePath, bool selected)
        {
            if (selected)
                System.Diagnostics.Process.Start("explorer.exe", "/select," + filePath);
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", filePath);
            }
        }

    }
}
