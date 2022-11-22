using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
            HostFilePath = "C:\\Users\\chen\\Documents\\test.txt";
        }

        public string _hostFilePath;
        public string _hostContents;
        public string _addHostContents;
        // public int IsAdmin => LoadAdminStatus();
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

        public string AddHostContents
        {
            get => _addHostContents;
            set => SetProperty(ref _addHostContents, value);
        }

        public string HostContents_Dev
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

        public ICommand LoadAddHostFileCommand
        {
            get
            {
                return new RelayCommand(LoadHostFile);
            }
        }

        public ICommand AddHostFileCommand
        {
            get
            {
                return new RelayCommand(AddHostFile);
            }
        }

        private void AddHostFile()
        {
           var path = "C:\\Users\\chen\\Documents\\test.txt.bak";
            File.WriteAllText(path, AddHostContents);
        }

        public ICommand SaveHostFileCommand
        {
            get
            {
                return new RelayCommand(SaveHostFile);
            }
        }

        //public ICommand LoadAdminStatusCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(LoadAdminStatus);
        //    }
        //}

        private bool IsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
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
            //var oldContents = File.ReadAllText(HostFilePath);
            //var temp = _hostContents;
            //return HostContents = File.ReadAllText(HostFilePath);
        }

        private void LoadAddHostFile()
        {
            if (string.IsNullOrEmpty("C:\\Users\\chen\\Documents\\test.txt.bak"))
            {
                MessageBox.Show("未获取到hosts文件路径");
                return;
            }
            AddHostContents = string.Empty;
            AddHostContents = File.ReadAllText(HostFilePath);
            //var oldContents = File.ReadAllText(HostFilePath);
            //var temp = _hostContents;
            //return HostContents = File.ReadAllText(HostFilePath);
        }



        private void SaveHostFile()
        {
            if (string.IsNullOrEmpty(HostContents) || string.IsNullOrEmpty(HostFilePath))
            {
                MessageBox.Show("未获取到hosts文件路径或hosts文件内容未空");
                return;
            }

            if (!IsAdmin() && HostFilePath.Equals($"{Environment.GetFolderPath(Environment.SpecialFolder.System)}\\driver\\etc\\hosts"))
            {
                MessageBox.Show("请用管理员身份尝试", "提示操作");
                return;
            }
            File.WriteAllText(HostFilePath, HostContents);
            LoadHostFile();
        }     
    }
}
