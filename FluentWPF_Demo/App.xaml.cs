using FluentWPF.Controls;
using System.Diagnostics;
using System.Windows;

namespace FluentWPF_Demo;

public partial class App : Application
{
    public App()
    {
        this.Startup += App_Startup;
    }

    private FluentWindow _window =null;

    private void App_Startup(object sender, StartupEventArgs e)
    {
        _window = new MainWindow();
        FluentWPF.Instance.InitTheme(this);
        FluentWPF.Instance.InstanceLogOutputEvent += Instance_InstanceLogOutputEvent;
        _window.Show();
    }

    private void Instance_InstanceLogOutputEvent(object sender, FluentWPF.Models.UILogModel message)
    {
        Debug.WriteLine(message.Message);
    }
}
