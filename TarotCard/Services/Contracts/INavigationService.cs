using System;
using System.Windows.Controls;

namespace WindowsInstaller.Services.Contracts;

public interface INavigationService
{
    public void RegisterFrame(Frame frame);

    public void UnregisterFrame();

    public void GoBack();


    public void GoForward();

    public void NavigationTo(object type);
}
