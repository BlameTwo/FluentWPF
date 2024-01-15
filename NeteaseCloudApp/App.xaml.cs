using System.Configuration;
using System.Data;
using System.Windows;

namespace NeteaseCloudApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _window;

        public App()
        {
            InitializeComponent();
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            this._window = new MainWindow();
            this.MainWindow = this._window;
            FluentWPF.Instance.InitTheme(_window,this);
            _window.Show();
        }
    }

}
