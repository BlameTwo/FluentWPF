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
}
