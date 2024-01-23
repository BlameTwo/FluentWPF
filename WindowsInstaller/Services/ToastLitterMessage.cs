using FluentWPF.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using WindowsInstaller.Services.Contracts;

namespace WindowsInstaller.Services;

public class ToastLitterMessage : IToastLitterMessage
{
    public Panel Owner { get; set; }

    public TimeSpan ShowTime { get; set; }

    [STAThread]
    public async Task ShowAsync(string message)
    {
        await Owner.Dispatcher.InvokeAsync((() =>
        {
            FluentTipCard control = new FluentTipCard();
            control.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            control.Margin = new System.Windows.Thickness(100,0,100,20);
            if(Owner as Grid != null)
            {
                var grid = Owner as Grid;
                if(grid.RowDefinitions.Count > 0)
                {
                    Grid.SetRow(control, (Owner as Grid).RowDefinitions.Count - 1);
                }
            }
            control.Content = message;
            control.Show(ShowTime, Owner);
        }));
    }

}
