using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentWPF.Contracts.Navigations;
using System.Collections.ObjectModel;
using TarotCard.Extentions;
using TarotCard.Services.Contracts;

namespace TarotCard.ViewModels;

public partial class MainViewModel:ObservableObject
{

    public MainViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    public INavigationService NavigationService { get; }

    [RelayCommand]
    void NavigationSelection(INavigationViewItem view)
    {
        NavigationService.NavigationTo(Register.GetService(NavigationTo.GetNavigationKey((System.Windows.DependencyObject)view)));
    }
}
