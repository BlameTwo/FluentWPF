using FluentWPF.Controls;
using FluentWPF.Win32;

namespace FluentWPF_Demo;

public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Light_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Light);
    }

    private void Dark_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Dark);
    }
}
