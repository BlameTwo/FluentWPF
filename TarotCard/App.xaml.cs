using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TarotCard
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup += App_Startup;
        }
        MainWindow _window;
        private async void App_Startup(object sender, StartupEventArgs e)
        {
            await Register.Init();
            _window = Register.GetService<MainWindow>();
            FluentWPF.Instance.InitTheme(_window,this);
            _window.Show();
        }
    }
}
