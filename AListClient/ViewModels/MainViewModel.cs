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
        var result = await  AListClient.LoginHash(this.UserName,this.Password);
        if(result != null)
        {
            AListClient.HttpClientProvider.Token = result.Token;
            var me = await AListClient.GetMe();
            var driverTemplate = await AListClient.GetDriverTemplate();
            foreach (var item in driverTemplate.Items)
            {
                Dictionary<string, string> value = new Dictionary<string, string>();
                foreach (var i in item.Common)
                {
                    value.Add(i.Name, i.Default);
                }
            }
        }
    }
}
