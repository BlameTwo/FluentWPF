using CommunityToolkit.Mvvm.ComponentModel;
using FluentWPF.Controls.SystemBackdrops;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WindowsInstaller.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    [ObservableProperty]
    string _ThemeName;

    [ObservableProperty]
    List<string> _Themes = new List<string>() { "Dark", "Light" };

    [ObservableProperty]
    string _SystemBackdropName;

    [ObservableProperty]
    List<string> _SystemBackdrops = new List<string>() { "Mica", "MicaAlt", "Acrylic" };

    partial void OnThemeNameChanged(string value)
    {
        switch (value)
        {
            case "Dark":
                FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Dark);
                break;
            case "Light":
                FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Light);
                break;
        }
    }

    partial void OnSystemBackdropNameChanged(string value)
    {
        switch (value)
        {
            case "Mica":
                FluentWPF.Instance.FluentWin.SystemBackdrop = new MicaBackdrop();
                break;
            case "MicaAlt":
                FluentWPF.Instance.FluentWin.SystemBackdrop = new MicaAltBackdrop();
                break;
            case "Acrylic":
                FluentWPF.Instance.FluentWin.SystemBackdrop = new AcrylicBackdrop();
                break;
        }
    }
}
