using FluentWPF.Controls;
using TarotCard.ViewModels;

namespace TarotCard
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
    }
}
