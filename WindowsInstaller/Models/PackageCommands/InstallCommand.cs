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
        this.Progress = new PackageCommandProgress();
        var result = await WinGetService.InstallPackageAsync(
            this.PackageBase,
            PackageInstallScope.Any,
            (s) => 
            {
                this.Progress.InstallProgress = s;
                this.ProgressState = s.State;
                switch (ProgressState)
                {
                    case PackageInstallProgressState.Queued:
                        this.TaskProgress = "0%";
                        break;
                    case PackageInstallProgressState.Downloading:
                        this.TaskProgress = s.DownloadProgress.ToString("P2");
                        break;
                    case PackageInstallProgressState.Installing:
                        this.TaskProgress = s.InstallationProgress.ToString("P2");
                        break;
                    case PackageInstallProgressState.PostInstall:
                        this.TaskProgress = "100%";
                        break;
                    case PackageInstallProgressState.Finished:
                        this.TaskProgress = "100%";
                        break;
                }
            }
        );
    }

    public void SetData(CatalogPackage data)
    {
        this.PackageBase = data;
        this.CommandType = Enums.CommandType.Install;
    }


    [ObservableProperty]
    PackageInstallProgressState _ProgressState;

    public IWinGetService WinGetService { get; }

    public override string CommandId =>
        this.PackageBase.Id??"";
}
