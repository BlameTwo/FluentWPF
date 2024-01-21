using System.Windows.Controls;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.Services;

public class NavigationService : INavigationService
{
    private Frame _frame;

    public void GoBack()
    {
        _frame!.GoBack();
    }

    public void GoForward()
    {
        _frame!.GoForward();
    }

    public void NavigationTo(object type)
    {
        _frame.Navigate(type); 
    }

    public void RegisterFrame(Frame frame)
    {
        this._frame = frame;
    }

    public void UnregisterFrame()
    {
        this._frame = null;
    }
}
