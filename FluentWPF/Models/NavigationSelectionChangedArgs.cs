using FluentWPF.Contracts.Navigations;

namespace FluentWPF.Models
{
    public class NavigationSelectionChangedArgs : EventArgs
    {
        public INavigationViewItem SelectItem { get; set; }
    }
}
