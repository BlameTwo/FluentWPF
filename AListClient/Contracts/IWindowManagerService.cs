using FluentWPF.Controls;

namespace AListClient.Contracts;

public interface IWindowManagerService
{
    public void ShowFileDriver();

    public FluentWindow ShowLogin();


    public void CloseFileDriver();

    public void CloseLogin();
}
