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

    public MainViewModel(IAListClient aListClient)
    {
        AListClient = aListClient;
    }

    public IAListClient AListClient { get; }

    [RelayCommand]
    async Task Login()
    {
        AListClient.SetIp(Ip);
        var result = await  AListClient.Login(this.UserName,this.Password);
        if(result != null)
        {
            MessageBox.Show("登陆成功");
        }
    }
}
