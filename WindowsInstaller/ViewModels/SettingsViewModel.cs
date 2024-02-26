using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentWPF.Controls.SystemBackdrops;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using Windows.UI.Text.Core;
using WindowsInstaller.Models;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    public SettingsViewModel(ILocalSettingsService localSettingsService)
    {
        LocalSettingsService = localSettingsService;
    }

    [ObservableProperty]
    string _ThemeName;

    [ObservableProperty]
    List<string> _Themes = new List<string>() { "Dark", "Light" };

    [ObservableProperty]
    string _SystemBackdropName;

    [ObservableProperty]
    string _FirstInstalledPath = "Default";

    [ObservableProperty]
    List<string> _SystemBackdrops = new List<string>() { "Mica", "MicaAlt", "Acrylic" };

    public ILocalSettingsService LocalSettingsService { get; }

    private InstallerConfig _config = null;

    [RelayCommand]
    async Task Loaded()
    {
        var result = await LocalSettingsService.ReadObjectValueAsync<InstallerConfig>("InstallerConfig");
        _config = new();
        if(result != null)
        {
            this._config = result;
        }
        this.ThemeName = result.Theme;
        this.SystemBackdropName = result.SystemBackdrop;
        this.FirstInstalledPath = result.InstallPath;
    }

    [RelayCommand]
    void ChangedFirstInstalledPath()
    {
        var dialog = new CommonOpenFileDialog();
        dialog.IsFolderPicker = true;
        if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            this.FirstInstalledPath = dialog.FileName;
        }
    }

    async partial void OnThemeNameChanged(string value)
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
        _config.Theme = value;
        await LocalSettingsService.WriteValueAsync<InstallerConfig>("InstallerConfig",_config);
    }

    async partial void OnSystemBackdropNameChanged(string value)
    {
        switch (value)
        {
            case "Mica":
                FluentWPF.Instance.UpdateSystemdrop(new MicaBackdrop());
                break;
            case "MicaAlt":
                FluentWPF.Instance.UpdateSystemdrop(new MicaAltBackdrop());
                break;
            case "Acrylic":
                FluentWPF.Instance.UpdateSystemdrop(new AcrylicBackdrop());
                break;
        }

        _config.SystemBackdrop = value;
        await LocalSettingsService.WriteValueAsync<InstallerConfig>("InstallerConfig", _config);
    }

    async partial void OnFirstInstalledPathChanged(string value)
    {
        _config.InstallPath = value;
        await LocalSettingsService.WriteValueAsync<InstallerConfig>("InstallerConfig", _config);
    }

}