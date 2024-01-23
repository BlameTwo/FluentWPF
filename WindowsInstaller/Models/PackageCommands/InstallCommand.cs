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
    public InstallCommand(IWinGetService winGetService,IToastLitterMessage toastLitterMessage)
    {
        WinGetService = winGetService;
        ToastLitterMessage = toastLitterMessage;
    }

    public override async Task ExecuteAsync()
    {
        this.Progress = new PackageCommandProgress();
        this._task = await WinGetService.InstallPackageAsync(
            this.PackageBase,
            PackageInstallScope.Any,
            async (s,value) => 
            {
                this.Progress.InstallProgress = value;
                this.ProgressState = value.State;
                switch (ProgressState)
                {
                    case PackageInstallProgressState.Queued:
                        this.TaskProgress = "0%";
                        break;
                    case PackageInstallProgressState.Downloading:
                        if (this.Cancel == true)
                        {
                            s.Cancel();
                            s.Close();
                            this.Cancel = false;
                            this.ProgressState = PackageInstallProgressState.Queued;
                            this.TaskProgress = "0%";
                            return;
                        }
                        this.TaskProgress = value.DownloadProgress.ToString("P2");
                        break;
                    case PackageInstallProgressState.Installing:
                        if(this.Cancel == true)
                            await ToastLitterMessage.ShowAsync("安装过程中不可取消任务！");
                        this.TaskProgress = value.InstallationProgress.ToString("P2");
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

    public override async Task CancelTaskAsync()
    {
        await Task.Run(() =>
        {
            if (this._task == null)
                return;
            this.Cancel = true;
        });
    }

    [ObservableProperty]
    PackageInstallProgressState _ProgressState;

    private InstallResultStatus _task;

    public IWinGetService WinGetService { get; }
    public IToastLitterMessage ToastLitterMessage { get; }

    public override string CommandId =>
        this.PackageBase.Id??"";

    public bool Cancel { get; private set; } = false;
}
