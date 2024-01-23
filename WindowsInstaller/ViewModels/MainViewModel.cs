using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Management.Deployment;
using System.Collections.ObjectModel;
using WindowsInstaller.Services.Contracts;
using System.Threading.Tasks;

namespace WindowsInstaller.ViewModels;

public partial class MainViewModel:ObservableObject
{
   

    public MainViewModel(INavigationService navigationService,IToastLitterMessage toastLitterMessage)
    {
        NavigationService = navigationService;
        ToastLitterMessage = toastLitterMessage;
    }

    [RelayCommand]
    async Task Loaded()
    {
    }


    

    public INavigationService NavigationService { get; }
    public IToastLitterMessage ToastLitterMessage { get; }

    [ObservableProperty]
    ObservableCollection<CatalogPackage> _Packages;

}
