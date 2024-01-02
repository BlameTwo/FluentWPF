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

    int i = 1;

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


    private void NavigationView_NavigationSelectionChanged(NavigationView sender, FluentWPF.Models.NavigationSelectionChangedArgs item)
    {

    }
}
