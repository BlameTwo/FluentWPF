using System;
using System.Globalization;
using System.Windows.Data;
using WindowsInstaller.Models.Enums;

namespace WindowsInstaller.Converters;

public class CommandTypeConverter:IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is CommandType command)
        {
            switch (command)
            {
                case CommandType.Install:
                    return "安装";
                case CommandType.Uninstall:
                    return "卸载";
                case CommandType.Upgrade:
                    return "更新";
            }
        }
        return "未知操作";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
