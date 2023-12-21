using FluentWPF.Common.Bases;
using FluentWPF.Contracts.Navigations;

namespace FluentWPF.Controls;

public class NavigationViewHeaderItem:ControlBase,INavigationViewItem
{


    public string Header
    {
        get { return (string)GetValue(HeaderProperty); }
        set { SetValue(HeaderProperty, value); }
    }

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register("Header", typeof(string), typeof(NavigationViewHeaderItem), new PropertyMetadata(null));


}
