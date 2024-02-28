using AListClient.ViewModels;
using AListClient.Views;
using FluentWPF.Controls;

namespace AListClient.Contracts.Services;

public class WindowManagerService : IWindowManagerService
{
    public FluentWindow FileWindow { get; private set; }

    public FluentWindow LoginWindow { get; private set; }

    public void CloseFileDriver()
    {
        if(FileWindow!= null) { FileWindow.Close(); }
    }

    public void CloseLogin()
    {
        if (LoginWindow != null) { LoginWindow.Close(); }
    }

    public void ShowFileDriver()
    {
        var file = Register.GetService<FileDriverView>();
        this.FileWindow = file;
        file.Show();
    }

    public FluentWindow ShowLogin()
    {
        var login = Register.GetService<MainWindow>();
        login.Show();
        this.LoginWindow = login;
        return login;
    }
}
