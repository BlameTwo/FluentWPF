using AListClient.Contracts;
using AListClient.Contracts.Services;
using AListClient.ViewModels;
using AListClient.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AListClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost Host { get; private set; }


        public App()
        {
            Host = Microsoft.Extensions.Hosting.Host
                .CreateDefaultBuilder()
                .RegisterService()
                .RegisterApp()
                .Build();
            this.Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            FluentWPF.Instance.InitTheme(this);
            var main = Register.GetService<IWindowManagerService>();
            this.MainWindow = main.ShowLogin();
        }
    }

    public static class Register
    {
        public static IHostBuilder RegisterService(this IHostBuilder builder)
        {
            builder.ConfigureServices(
                (context, server) =>
                {
                    server.AddSingleton<IHttpClientProvider, HttpClientProvider>();
                    server.AddSingleton<IAListClient, Contracts.Services.AListClient>();
                    server.AddSingleton<IWindowManagerService, WindowManagerService>();
                }
            );
            return builder;
        }

        public static IHostBuilder RegisterApp(this IHostBuilder builder)
        {
            builder.ConfigureServices(
                (context, server) =>
                {
                    server.AddSingleton<MainViewModel>();
                    server.AddSingleton<MainWindow>();
                    server.AddSingleton<FileDriverViewModel>();
                    server.AddSingleton<FileDriverView>();
                }
            );
            return builder;
        }

        public static T GetService<T>() where T : class
        {
            if (App.Host.Services.GetService<T>() is not T t)
            {
                return default;
            }
            return t;
        }
    }
}
