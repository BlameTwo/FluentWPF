using FluentWPF.Controls;
using WindowsInstaller.Extentions;
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

        private void navigationView_NavigationSelectionChanged(NavigationView sender, FluentWPF.Models.NavigationSelectionChangedArgs item)
        {
            var index = NavigationTo.GetNavigationKey((System.Windows.DependencyObject)item.SelectItem!);
            (this.DataContext as MainViewModel).NavigationService.NavigationTo(Register.GetService(index));
        }

        private void NavigationViewItem_ItemInvoked(NavigationViewItem sender, System.Windows.RoutedEventArgs args)
        {

        }
    }
}
