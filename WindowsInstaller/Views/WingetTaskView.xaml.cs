using System.Windows;
using System.Windows.Controls;
using WindowsInstaller.ViewModels;

namespace WindowsInstaller.Views;


public partial class WingetTaskView : Page
{
    public WingetTaskView()
    {
        InitializeComponent();
        this.DataContext =Register.GetService<WinGetTaskViewModel>();
    }

}
