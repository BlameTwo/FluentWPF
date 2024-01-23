using System;
using System.Windows;

namespace WindowsInstaller.Extentions;

public class NavigationTo
{
    public static string GetNavigationKey(DependencyObject obj)
    {
        return (string)obj.GetValue(NavigationKeyProperty);
    }

    public static void SetNavigationKey(DependencyObject obj, string value)
    {
        obj.SetValue(NavigationKeyProperty, value);
    }


    public static readonly DependencyProperty NavigationKeyProperty =
        DependencyProperty.RegisterAttached("NavigationKey", typeof(string), typeof(NavigationTo), new PropertyMetadata(null));



    public static Type GetNavigationType(DependencyObject obj)
    {
        return (Type)obj.GetValue(NavigationTypeProperty);
    }

    public static void SetNavigationType(DependencyObject obj, Type value)
    {
        obj.SetValue(NavigationTypeProperty, value);
    }

    public static readonly DependencyProperty NavigationTypeProperty =
        DependencyProperty.RegisterAttached("NavigationType", typeof(Type), typeof(NavigationTo), new PropertyMetadata(null));


}
