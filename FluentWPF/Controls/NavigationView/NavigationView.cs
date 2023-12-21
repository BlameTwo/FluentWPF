using FluentWPF.Common.Bases;
using FluentWPF.Contracts.Navigations;

namespace FluentWPF.Controls;

public sealed partial class NavigationView : ControlBase, INavigationView
{
    public List<INavigationViewItem> MenuItems
    {
        get { return (List<INavigationViewItem>)GetValue(MenuItemsProperty); }
        set { SetValue(MenuItemsProperty, value); }
    }

    public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(
        "MenuItems",
        typeof(List<INavigationViewItem>),
        typeof(NavigationView),
        new PropertyMetadata(0)
    );
}
