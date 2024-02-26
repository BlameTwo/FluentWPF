using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using System.Windows;
using WindowsInstaller.Models;
using WindowsInstaller.Resources;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller;

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
        Dictionary<string, object> keys = new()
        {
            { "InstallerConfig",InstallerConfig.CreateDefault() }
        };
        await Register.Init();
        await Register.GetService<ILocalSettingsService>().InitSettingsAsync(keys);
        _window = Register.GetService<MainWindow>();
        FluentWPF.Instance.InitTheme(this);
        _window.Show();
    }
}
