using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TarotCard.Resources;

namespace TarotCard
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:验证平台兼容性", Justification = "<挂起>")]
        public App()
        {
            InitializeComponent();
            Startup += App_Startup;
            AppCenter.Start(Apis.AppCenterAPI,typeof(Analytics),typeof(Crashes));
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
