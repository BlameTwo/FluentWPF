using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WindowsInstaller.Models;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.ViewModels;

public partial class WinGetTaskViewModel:ObservableRecipient
{
    public WinGetTaskViewModel(IPackageTaskMananger packageTaskMananger)
    {
        PackageTaskMananger = packageTaskMananger;
        this.PackageCommands = new();
    }

    [RelayCommand]
    void Loaded()
    {
        Refresh();
    }

    [ObservableProperty]
    PackageCommandBase _PackageCommandSelectItem;

    void Refresh()
    {
        this.PackageCommands.Clear();
        this.PackageCommands = PackageTaskMananger.GetPackages();
    }

    public IPackageTaskMananger PackageTaskMananger { get; }

    [ObservableProperty]
    ObservableCollection<PackageCommandBase> _PackageCommands;
}
