using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Management.Deployment;
using System;
using System.Threading.Tasks;
using Windows.Management.Deployment;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.Models.PackageCommands;

/// <summary>
/// 安装命令
/// </summary>
public partial class InstallCommand : PackageCommandBase, ITaskCommand<CatalogPackage>
{
    public InstallCommand(IWinGetService winGetService)
    {
        WinGetService = winGetService;
    }

    public override async Task ExecuteAsync()
    {
        var result = await WinGetService.InstallPackageAsync(
            this.PackageBase,
            PackageInstallScope.Any,
            (s) => 
            {
                this.DownloadProgressValue = Math.Round(s.DownloadProgress * 100,2);
                this.InstallingProgressValue = Math.Round(s.InstallationProgress*100,2);
                this.ProgressState = s.State;
            }
        );
    }

    public void SetData(CatalogPackage data)
    {
        this.PackageBase = data;
        this.CommandType = Enums.CommandType.Install;
    }

    [ObservableProperty]
    double _DownloadProgressValue;

    [ObservableProperty]
    double _InstallingProgressValue;

    [ObservableProperty]
    PackageInstallProgressState _ProgressState;

    public IWinGetService WinGetService { get; }

    public override string CommandId =>
        this.PackageBase.Id??"";
}
