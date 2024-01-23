using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Management.Deployment;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.ViewModels;

public partial class PackageManagerViewModel:ObservableRecipient
{
    public PackageManagerViewModel(IWinGetService winGetService)
    {
        WinGetService = winGetService;
    }

    [ObservableProperty]
    ObservableCollection<CatalogPackage> _Packages = new();

    public IWinGetService WinGetService { get; }

    [RelayCommand]
    async void Loaded()
    {
        this.Packages =  await WinGetService.GetLocalAppAsync("winget");
    }
}
