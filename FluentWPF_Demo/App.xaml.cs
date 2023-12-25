using FluentWPF.Controls;
using System.Windows;

namespace FluentWPF_Demo;

public partial class App : Application
{
    public App()
    {
        this.Startup += App_Startup;
    }

    private DefaultWindow _window =null;

    private void App_Startup(object sender, StartupEventArgs e)
    {
        _window = new  DefaultWindow();
        //FluentWPF.Instance.InitTheme(_window,this);
        _window.Show();
    }
}
