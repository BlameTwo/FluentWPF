using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WindowsInstaller.Services.Contracts;

public interface IToastLitterMessage
{
    public Panel Owner { get; set; }

    public TimeSpan ShowTime { get; set; }

    [STAThread]
    public Task ShowAsync(string message);
}
