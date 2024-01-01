using System.Collections.ObjectModel;

namespace FluentWPF.Contracts.Navigations;

public interface INavigationView
{
    public List<INavigationViewItem> MenuItems { get; }

    public event NavigationSelectionDelegate NavigationSelectionChanged;
}
