using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp2.ViewModel
{
    public class ViewHosteditor : ObservableObject
    {
        public ViewHosteditor()
        {
            init();
        }
        private void init()
        {
            //HostFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.System)}\\driver\\etc\\hosts";
            HostFilePath = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        }

        private string _hostFilePath;
        private string _hostContents;
        public string HostFilePath
        {
            get => _hostFilePath;
            set => SetProperty(ref _hostFilePath, value);
        }
        public string HostContents
        {
            get => _hostContents;
            set => SetProperty(ref _hostContents, value);
        }

        public ICommand LoadHostFileCommand
        {
            get
            {
                return new RelayCommand(LoadHostFile);
            }
        }

        public ICommand SaveHostFileCommand
        {
            get
            {
                return new RelayCommand(SaveHostFile);
            }
        }

        private void LoadHostFile()
        {
            if (string.IsNullOrEmpty(HostFilePath))
            {
                MessageBox.Show("未获取到hosts文件路径");
                return;
            }
            HostContents = string.Empty;
            HostContents = File.ReadAllText(HostFilePath);
        }


        private void SaveHostFile()
        {
            if (string.IsNullOrEmpty(HostContents) || string.IsNullOrEmpty(HostFilePath))
            {
                MessageBox.Show("未获取到hosts文件路径或hosts文件内容未空");
                return;
            }
            try
            {
                File.WriteAllText(HostFilePath, HostContents);
                LoadHostFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"写入出错:{ex.Message}\r\n请用管理员身份尝试");
            }
        }
    }
}
