using FluentWPF.Common.Bases;
using FluentWPF.Contracts.Navigations;
using FluentWPF.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FluentWPF.Controls;

/// 向上出现
[TemplateVisualState(GroupName = "FlageStateGroup", Name = "TopStart")]

///向下出现
[TemplateVisualState(GroupName = "FlageStateGroup", Name = "TopEnd")]

///向上消失
[TemplateVisualState(GroupName = "FlageStateGroup", Name = "BootomStart")]

///向下消失
[TemplateVisualState(GroupName = "FlageStateGroup", Name = "BootomEnd")]
public partial class NavigationViewItem : ButtonBase, INavigationViewItem
{
    public NavigationViewItem() { }

    public FontIconEnum Icon
    {
        get { return (FontIconEnum)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        "Icon",
        typeof(FontIconEnum),
        typeof(NavigationViewItem),
        new PropertyMetadata(null)
    );

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        var navigation = NavigationView.GetNavigationView(this);
        navigation?.OnSelected(this);
        base.OnMouseLeftButtonUp(e);
    }


    public void RefreshPanel(NavigationDisplayMode mode, bool isOpen)
    {
    }

    public bool IsSelect
    {
        get { return (bool)GetValue(IsSelectProperty); }
        set { SetValue(IsSelectProperty, value); }
    }

    public static readonly DependencyProperty IsSelectProperty = DependencyProperty.Register(
        "IsSelect",
        typeof(bool),
        typeof(NavigationViewItem),
        new PropertyMetadata(false)
    );
}
