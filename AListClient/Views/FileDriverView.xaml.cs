using AListClient.ViewModels;
using FluentWPF.Controls;

namespace AListClient.Views;

public partial class FileDriverView : FluentWindow
{
    public FileDriverView()
    {
        InitializeComponent();
        this.DataContext = Register.GetService<FileDriverViewModel>();
    }
}
