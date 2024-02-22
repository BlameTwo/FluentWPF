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



/* 项目“FluentWPF_Demo (net472)”的未合并的更改
在此之前:
    private void NavigationView_NavigationSelectionChanged(NavigationView sender, FluentWPF.Models.NavigationSelectionChangedArgs item)
在此之后:
    private void NavigationView_NavigationSelectionChanged(NavigationView sender, NavigationSelectionChangedArgs item)
*/
    private void NavigationView_NavigationSelectionChanged(NavigationView sender, FluentWPF.Models.Args.NavigationSelectionChangedArgs item)
    {

    }
}
