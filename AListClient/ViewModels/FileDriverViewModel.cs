using AListClient.Contracts;
using AListClient.Models.Storage.StorageList;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AListClient.ViewModels;

public sealed partial class FileDriverViewModel : ObservableRecipient
{
    public FileDriverViewModel(IAListClient aListClient)
    {
        AListClient = aListClient;
    }

    [RelayCommand]
    async Task Loaded()
    {
        var result = await AListClient.GetStorageList(1,20);
        if (result != null)
        {
            this.Storages = new(result.Content);
        }
    }

    [ObservableProperty]
    ObservableCollection<StorageContent> _Storages;

    public IAListClient AListClient { get; }
}
