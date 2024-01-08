using CommunityToolkit.Mvvm.ComponentModel;
using TarotCard.Services.Contracts;

namespace TarotCard.ViewModels;

public partial class ShouldViewModel:ObservableObject
{
    public ShouldViewModel(IGetTarotService getTarotService)
    {
        GetTarotService = getTarotService;
    }

    public IGetTarotService GetTarotService { get; }
}
