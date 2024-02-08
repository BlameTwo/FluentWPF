using System.Windows;

namespace ToolkitBox;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private MainWindow _mainWindow;

    public App()
    {
        Startup += App_Startup;
    }

    private void App_Startup(object sender, StartupEventArgs e)
    {
        this._mainWindow = new MainWindow();
        this.MainWindow = _mainWindow;
        FluentWPF.Instance.InitTheme(_mainWindow, this);
        _mainWindow.Show();
    }
}
