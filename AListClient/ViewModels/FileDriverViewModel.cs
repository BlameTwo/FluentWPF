using AListClient.Contracts;
using AListClient.Models.FileServer.FileLists;
using AListClient.Models.Storage.StorageList;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AListClient.ViewModels;

public sealed partial class FileDriverViewModel : ObservableRecipient
{
    public FileDriverViewModel(IAListClient aListClient, ICloudFileService cloudFileService)
    {
        AListClient = aListClient;
        CloudFileService = cloudFileService;
    }

    [RelayCommand]
    async Task Loaded()
    {
        var result = await CloudFileService.GetFolderList(new("/",1,20,false));
        this.Storages = new(result.Content);
    }

    [ObservableProperty]
    ObservableCollection<FSContent> _Storages;

    public IAListClient AListClient { get; }
    public ICloudFileService CloudFileService { get; }
}
