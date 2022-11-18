using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Model;
using System.IO;

namespace WpfApp2.ViewModel
{
    class ProductVM : Utilities.ViewModelBase
    {
        const string Path = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        private readonly PageModel _pageModel;
        public string ProductAvailability
        {
            get { return _pageModel.ProductStatus; }
            set { _pageModel.ProductStatus = value; OnPropertyChanged(); }
        }

        //public ICommand SaveHosts()
        //{
        //    return new ICommand();
        //}

        public string Init()
        {
            return File.ReadAllText(Path);
        }
        public ICommand AddProductCommand { get; set; }
        //public ICommand AddProductCommand()
        //{
        //    return null;
        //}
        public ProductVM()
        {
            _pageModel = new PageModel();
            ProductAvailability = "Out of Stock";
        }


        public void loadButton_Click(object sender, RoutedEventArgs e)
        {

            var str = File.ReadAllText(Path);
            textBox.Text = str;
            wordCount.Content = "word : " + str.Count().ToString();
        }

        //private void saveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var contents = textBox.Text;
        //    if (string.IsNullOrEmpty(contents))
        //    {
        //        MessageBox.Show("file is empty");
        //        return;
        //    }
        //    File.WriteAllText(Path, contents);
        //    wordCount.Content = "word : " + contents.Count().ToString();
        //    MessageBox.Show("Save Success");
        //}
    }
}
