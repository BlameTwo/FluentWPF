using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TarotCard.Extentions;
using TarotCard.Models;
using TarotCard.Services.Contracts;

namespace TarotCard.ViewModels;

public sealed partial class AllCardViewModel:ObservableObject
{
    public AllCardViewModel(IGetTarotService getTarotService)
    {
        GetTarotService = getTarotService;
    }

    [ObservableProperty]
    ObservableCollection<ImageTarotCard> _Cards;

    [RelayCommand]
    async Task Loaded()
    {
        Cards = new();
        var random =  (await GetTarotService.GetAllCard()).FromatImage();
        foreach (var item in random)
        {
            this.Cards.Add(item);
        }
    }


    public IGetTarotService GetTarotService { get; }
}
