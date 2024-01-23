using System;
using System.Globalization;
using System.Windows.Data;

namespace WindowsInstaller.Converters;

public class DateTimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is DateTimeOffset time && parameter is string paramterstr)
        {
            return time.ToString(paramterstr);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
