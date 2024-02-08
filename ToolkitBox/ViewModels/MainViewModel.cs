
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToolkitBox.ViewModels;

public partial class MainViewModel:ObservableRecipient
{
    public MainViewModel()
    {

    }

    [RelayCommand]
    void ShowSetting()
    {
    }
}