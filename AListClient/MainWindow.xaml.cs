using AListClient.ViewModels;
using AListClient.Views;
using FluentWPF.Controls;

namespace AListClient;

public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = Register.GetService<MainViewModel>();
        FluentWPF.Instance.ApplyTheme(FluentWPF.Models.Enums.ThemeTypeEnum.Dark);
    }

}