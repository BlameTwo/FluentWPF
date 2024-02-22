using FluentWPF.Controls;
using System;
using WindowsInstaller.Extentions;
using WindowsInstaller.Services.Contracts;
using WindowsInstaller.ViewModels;

namespace WindowsInstaller
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : FluentWindow
    {
        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            (this.DataContext as MainViewModel).NavigationService.RegisterFrame(this.frameBase);
        }

        private void frameBase_LoadCompleted(
            object sender,
            System.Windows.Navigation.NavigationEventArgs e
        )
        {
            if (!frameBase.CanGoBack) return;
            var entry = this.frameBase.RemoveBackEntry();
            while (entry != null)
            {
                entry = this.frameBase.RemoveBackEntry();
            }
        }





        private void FluentWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if(this.DataContext is MainViewModel vm)
            {
                vm.ToastLitterMessage.Owner = this.grid;
                vm.ToastLitterMessage.ShowTime = TimeSpan.FromSeconds(2);
            }
        }

        private void navigationView_NavigationSelection(NavigationView sender, FluentWPF.Models.Args.NavigationSelectionChangedArgs args)
        {
            var index = NavigationTo.GetNavigationKey(args.SelectItem);
            (this.DataContext as MainViewModel).NavigationService.NavigationTo(index);
        }

        private void NavigationViewItem_ItemInvoked(NavigationViewItem sender, FluentWPF.Models.Args.NavigationItemInvokedArgs args)
        {

        }
    }
}
