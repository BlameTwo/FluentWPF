using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Management.Deployment;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.ViewModels;

public partial class SearchViewModel:ObservableRecipient
{
    [ObservableProperty]
    string _Query;

    [ObservableProperty]
    ObservableCollection<CatalogPackage> _Packages=new();

    [ObservableProperty]
    CatalogPackage _Package;

    [ObservableProperty]
    List<string> _Source = new() { "winget","msstore"};

    public SearchViewModel(IWinGetService winGetService,IPackageTaskMananger packageTaskMananger,IWinGetDataService winGetDataService)
    {
        WinGetService = winGetService;
        PackageTaskMananger = packageTaskMananger;
        WinGetDataService = winGetDataService;
    }

    public IWinGetService WinGetService { get; }
    public IPackageTaskMananger PackageTaskMananger { get; }
    public IWinGetDataService WinGetDataService { get; }
    public IToastLitterMessage ToastLitterMessage { get; }

    [RelayCommand]
    async void InstallAppAsync()
    {
        var result =  PackageTaskMananger.Add(this.WinGetDataService.GetInstallCommand(this.Package));
        await Register.GetService<IToastLitterMessage>().ShowAsync($"{result.Item1}：{result.Item2}");
    }

    [RelayCommand]
    async void FindAsync(string source)
    {
        Packages.Clear();
        Packages = await WinGetService.SearchAsync(source,Query);
    }
}
