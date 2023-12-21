using FluentWPF.Common.Bases;
using FluentWPF.Contracts.Navigations;

namespace FluentWPF.Controls;


/// <summary>
/// 可点击的导航子项
/// </summary>
public class NavigationViewItem:ButtonBase,INavigationViewItem
{


    public object Content
    {
        get { return (object)GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }

    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(NavigationViewItem), new PropertyMetadata(null));


}
