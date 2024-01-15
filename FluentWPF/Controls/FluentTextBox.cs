using System.Windows.Controls;

namespace FluentWPF.Controls;

public class FluentTextBox : TextBox
{
    public CornerRadius CornerRadius
    {
        get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        "CornerRadius",
        typeof(CornerRadius),
        typeof(FluentTextBox),
        new PropertyMetadata(default(CornerRadius))
    );
}
