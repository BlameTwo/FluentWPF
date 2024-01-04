using FluentWPF.Contracts.Navigations;
using System.Runtime.CompilerServices;

namespace FluentWPF.Controls;

partial class NavigationView
{
    private static void OnDisplayModeChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e
    )
    {
        if (e.NewValue is NavigationDisplayMode mode && d is NavigationView view)
        {
            switch (mode)
            {
                case NavigationDisplayMode.Open:
                    VisualStateManager.GoToState(view, "Open", false);
                    view.IsPaneOpen = true;
                    break;
                case NavigationDisplayMode.Close:
                    VisualStateManager.GoToState(view, "Close", false);
                    view.IsPaneOpen = false;
                    break;
            }
        }
    }

    private static void OnIsPaneOpenChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e
    )
    {
        if (e.NewValue is bool val && d is NavigationView view)
        {
            VisualStateManager.GoToState(view, val == true ? "Open" : "Close", false);
        }
    }

    private void NavigationView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (this.DisplayMode != NavigationDisplayMode.Auto)
            return;
        if (this.ActualWidth < 600)
        {
            VisualStateManager.GoToState(this, "DefaultAutoOpen", false);
            VisualStateManager.GoToState(this, "Close", false);
            this.IsPaneOpen = false;
        }
        else
        {
            VisualStateManager.GoToState(this, "MinAutoOpen", false);
            VisualStateManager.GoToState(this, "Open", false);
            this.IsPaneOpen = true;
        }
    }

    /*
     TopStart,
     TopEnd,
     BootomStart,
     BootomEnd
     */

    internal void OnSelected(INavigationViewItem item)
    {
        if (item is not NavigationViewItem)
            return;
        if (item is not FrameworkElement obj)
            return;
        if (this.SelectItem == null)
        {
            this.SelectItem = item;
            item.IsSelect = true;
        }
        else if (this.SelectItem != item)
        {
            //新项目是否在主菜单中
            var isMenu = MenuItems.IndexOf(item) != -1;
            //新项目是否在脚部菜单
            var isFolter = FooterItems.IndexOf(item) != -1;
            //旧项目是否在主菜单中
            var oldisMenu = MenuItems.IndexOf(this.SelectItem) != -1;
            //旧项目是否在脚部菜单
            var oldisFolter = FooterItems.IndexOf(this.SelectItem) != -1;
            if (isMenu && oldisMenu)//新项目在主菜单，旧项目不在，从下到上
            {
                // 向上消失
                VisualStateManager.GoToState(obj, "BootomStart", false);
                // 向下出现
                VisualStateManager.GoToState((this.SelectItem as FrameworkElement), "TopEnd", false);
            }
            if(isMenu == false && oldisMenu)//新项目不在主菜单，旧项目在主菜单
            {
                //向下消失
                VisualStateManager.GoToState(obj, "FlageStateGroup", false);
                VisualStateManager.GoToState((this.SelectItem as FrameworkElement), "BootomStart", false);
            }
            this.SelectItem.IsSelect = false;
            this.SelectItem = item;
            item.IsSelect = true;
        }
        this.NavigationSelectionDelegateHandler?.Invoke(
            this,
            new Models.NavigationSelectionChangedArgs() { SelectItem = item }
        );
    }
}
