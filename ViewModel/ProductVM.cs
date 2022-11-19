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
using System.Data.Common;

namespace WpfApp2.ViewModel
{
    class ProductVM : Utilities.ViewModelBase
    {
        const string Path = "C:\\Users\\chen\\Documents\\test.txt";
        //private readonly PageModel _pageModel;

        public string _productAvailability;
        public string ProductAvailability
        {
            get=> _productAvailability; 
            set
            {
                _productAvailability = value;
                OnPropertyChanged("ProductAvailability");
            }
        }


        public string Init()
        {
            return File.ReadAllText(Path);
        }
        private readonly DelegateCommand _changeCommand;
        public ICommand ChangeCommand => _changeCommand;


        public ProductVM()
        {
            _changeCommand = new DelegateCommand(DoSomething, CanDoSomething);
        }

        private bool CanDoSomething(object arg)
        {
            return true;
        }

        private void DoSomething(object obj)
        {
            ProductAvailability = Init();
            _changeCommand.InvokeCanExecuteChanged();
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

    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public void Execute(object parameter) => _executeAction(parameter);

        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

        public event EventHandler CanExecuteChanged;

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
