using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using TarotCard.ViewModels;

namespace TarotCard.Views
{
    /// <summary>
    /// AllCardsView.xaml 的交互逻辑
    /// </summary>
    public partial class AllCardsView : Page
    {
        public AllCardsView(AllCardViewModel card)
        {
            InitializeComponent();
            this.DataContext = card;
        }

    }
}
