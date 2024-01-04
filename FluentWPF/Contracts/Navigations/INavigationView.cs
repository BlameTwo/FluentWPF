using System.Collections.ObjectModel;

namespace FluentWPF.Contracts.Navigations;

public interface INavigationView
{
    public ObservableCollection<INavigationViewItem> MenuItems { get; set; }

    public ObservableCollection<INavigationViewItem> FooterItems { get; set; }

    public event NavigationSelectionDelegate NavigationSelectionChanged;
}
