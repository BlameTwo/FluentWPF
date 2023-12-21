using CommunityToolkit.Mvvm.ComponentModel;

namespace FluentWPF_Demo.ViewModels;

public sealed partial class MainViewModel:ObservableObject
{
    [ObservableProperty]
    bool _ThemeSwitch;
}
