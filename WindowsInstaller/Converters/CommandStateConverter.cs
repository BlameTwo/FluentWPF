using Microsoft.Management.Deployment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WindowsInstaller.Converters
{
    class CommandStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is PackageInstallProgressState state)
            {
                switch (state)
                {
                    case PackageInstallProgressState.Queued:
                        return "队列中";
                    case PackageInstallProgressState.Downloading:
                        return "下载中";
                    case PackageInstallProgressState.Installing:
                        return "安装中";
                    case PackageInstallProgressState.PostInstall:
                        return "安装后";
                    case PackageInstallProgressState.Finished:
                        return "完毕";
                    default:
                        break;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
