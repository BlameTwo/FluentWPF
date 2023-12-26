using FluentWPF.Common.Bases;
using FluentWPF.Contracts.Navigations;
using System.Windows.Markup;
using System.Windows.Media;

namespace FluentWPF.Controls;

[ContentProperty(nameof(Content))]
public partial class NavigationView : ControlBase, INavigationView
{
    public NavigationView()
    {
        this.NavigationParent = this;
    }

    
}
