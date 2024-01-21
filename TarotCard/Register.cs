using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WindowsInstaller.Services;
using WindowsInstaller.Services.Contracts;
using WindowsInstaller.ViewModels;

namespace WindowsInstaller;

public static class Register
{
    public static IHost Host { get; private set; }

    public async static Task Init()
    {
        Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, service) => 
            {
                service.AddSingleton<MainWindow>();
                service.AddSingleton<MainViewModel>();
                service.AddSingleton<INavigationService,NavigationService>();
            })
            .Build();
        await Host.StartAsync();
    }

    internal static T GetService<T>()
    {
        return Host.Services.GetRequiredService<T>();
    }

    internal static object GetService(Type serviceType)
    {
        try
        {
            return Host.Services.GetRequiredService(serviceType);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
