using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WindowsInstaller.Models.PackageCommands;
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

                service.AddTransient<SearchViewModel>();
                service.AddTransient<PackageManagerViewModel>();
                service.AddTransient<SettingsViewModel>();
                service.AddTransient<WinGetTaskViewModel>();

                //Winget核心控制
                service.AddSingleton<IWinGetService, WinGetService>();

                //管理包任务
                service.AddSingleton<IPackageTaskMananger, PackageTaskManager>();
                //数据适配器
                service.AddTransient<IWinGetDataService, WinGetDataService>();

                //设置
                service.AddSingleton<ILocalSettingsService,LocalSettingsService>();

                service.AddSingleton<IToastLitterMessage, ToastLitterMessage>();

                //应用导航
                service.AddSingleton<INavigationService,NavigationService>();

                #region 任务类型
                service.AddTransient<InstallCommand>();
                #endregion
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
