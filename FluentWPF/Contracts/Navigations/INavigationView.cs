namespace FluentWPF.Contracts.Navigations;

public interface INavigationView
{
    public List<INavigationViewItem> MenuItems { get; set; }
}