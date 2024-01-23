using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Management.Deployment;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using WindowsInstaller.Models.Enums;

namespace WindowsInstaller.Models;

public delegate void PackageProgressChanged(object sender, InstallProgress progress);

/// <summary>
/// 包基础命令
/// </summary>
public abstract partial class PackageCommandBase:ObservableObject
{
    [ObservableProperty]
    CatalogPackage _PackageBase;

    /// <summary>
    /// 执行命令
    /// </summary>
    /// <returns></returns>
    public abstract Task ExecuteAsync();

    [RelayCommand]
    async Task ExecuteAsyncCommand() => await ExecuteAsync();
    
    public abstract string CommandId { get;  }

    [ObservableProperty]
    CommandType _CommandType;

    [ObservableProperty]
    string _TaskProgress;

    [ObservableProperty]
    PackageCommandProgress _Progress;

    private PackageProgressChanged? packageProgressChanged;
    public event PackageProgressChanged PackageProgressEvent
    {
        add => packageProgressChanged += value;
        remove => packageProgressChanged -= value;
    }
}

public class PackageCommandProgress
{
    public InstallProgress InstallProgress { get; set; }

    public UninstallProgress UninstallProgress { get; set; }

}
