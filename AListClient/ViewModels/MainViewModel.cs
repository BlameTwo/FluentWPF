using AListClient.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace AListClient.ViewModels;

public sealed partial class MainViewModel:ObservableRecipient
{

    [ObservableProperty]
    string _UserName;

    [ObservableProperty]
    string _Password;

    [ObservableProperty]
    string _Ip;

    public MainViewModel(IAListClient aListClient, IWindowManagerService windowManagerService)
    {
        AListClient = aListClient;
        WindowManagerService = windowManagerService;
    }

    public IAListClient AListClient { get; }
    public IWindowManagerService WindowManagerService { get; }

    [RelayCommand]
    async Task Login()
    {
        AListClient.SetIp(Ip);
        var result = await  AListClient.LoginHash(this.UserName,this.Password);
        if(result != null)
        {
            AListClient.HttpClientProvider.Token = result.Token;
            WindowManagerService.ShowFileDriver();
            WindowManagerService.CloseLogin();
        }
    }
}
