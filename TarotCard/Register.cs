using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TarotCard.Services;
using TarotCard.Services.Contracts;
using TarotCard.ViewModels;
using TarotCard.Views;

namespace TarotCard;

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

                service.AddTransient<ShouldView>();
                service.AddTransient<ShouldViewModel>();
                service.AddTransient<DailyView>();
                service.AddTransient<DailyViewModel>();
                service.AddTransient<SettingsView>();
                service.AddTransient<SettingsViewModel>();
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
        return Host.Services.GetRequiredService(serviceType);
    }
}
