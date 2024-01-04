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

    internal void OnSelected(INavigationViewItem item)
    {
        if (item is not NavigationViewItem)
            return;
        if (this.SelectItem == null)
        {
            this.SelectItem = item;
            item.IsSelect = true;
        }
        else if (this.SelectItem != item)
        {
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
