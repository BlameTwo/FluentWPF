using System.Globalization;
using System.Windows.Data;

namespace FluentWPF.Converters;

public class NavigationMenuOpenConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if((value as bool?) == true)
        {
            return NavigationDisplay.Open;
        }
        else
        {
            return NavigationDisplay.Close;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is NavigationDisplay dis)
        {
            return dis == NavigationDisplay.Open ? true : false;
        }
        return false;
    }
}
