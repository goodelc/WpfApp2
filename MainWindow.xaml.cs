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
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string Path = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        //const string Path = "D:\\WPFTest\\111.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {

            var str = File.ReadAllText(Path);
            textBox.Text = str;
            wordCount.Content = "word : " + str.Count().ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var contents = textBox.Text;
            if (string.IsNullOrEmpty(contents))
            {
                MessageBox.Show("file is empty");
                return;
            }
            File.WriteAllText(Path, contents);
            wordCount.Content = "word : " + contents.Count().ToString();
            MessageBox.Show("Save Success");
        }
    }
}
