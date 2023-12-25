using FluentWPF.Controls;
using FluentWPF_Demo.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace FluentWPF_Demo;

public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }

    private void FluentToggleButton_Click(object sender, RoutedEventArgs e)
    {
        if(sender is FluentToggleButton button && (bool)button.IsChecked!)
        {
            FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Dark);
        }
        else
        {
            FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Light);
        }
    }
}
