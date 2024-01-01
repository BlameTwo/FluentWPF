namespace FluentWPF.Contracts.Navigations;

public interface INavigationViewItem
{
    public object Content { get; set; }

    public bool IsSelect { get; set; }
}
