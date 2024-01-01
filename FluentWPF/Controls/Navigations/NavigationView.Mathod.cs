using FluentWPF.Contracts.Navigations;

namespace FluentWPF.Controls;

partial class NavigationView
{


    private static void OnDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue is NavigationDisplay mode && d is NavigationView view)
        {
            switch (mode)
            {
                case NavigationDisplay.Open:
                    VisualStateManager.GoToState(view, "Open", false);
                    break;
                case NavigationDisplay.Close:
                    VisualStateManager.GoToState(view, "Close", false);
                    break;
                case NavigationDisplay.Min:
                    break;
            }
        }
    }



    internal void OnSelected(INavigationViewItem item)
    {
        if (item is not NavigationViewItem) return;
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
        this.NavigationSelectionDelegateHandler?.Invoke(this, item);
    }
}
