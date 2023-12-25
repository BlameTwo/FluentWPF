namespace FluentWPF.Controls;

public class SystemWindow:Window
{
    public SystemWindow()
    {

        DefaultStyleKeyProperty.OverrideMetadata(typeof(SystemWindow), new FrameworkPropertyMetadata(typeof(SystemWindow)));
        
    }
}
