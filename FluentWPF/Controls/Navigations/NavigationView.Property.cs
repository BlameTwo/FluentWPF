using FluentWPF.Contracts.Navigations;
using System.Windows.Media;

namespace FluentWPF.Controls
{
    partial class NavigationView
    {
        //使用附加属性的继承方式写入顶层控件
        internal INavigationView NavigationParent
        {
            get => (INavigationView)GetValue(NavigationParentProperty);
            set => SetValue(NavigationParentProperty, value);
        }

        public static readonly DependencyProperty NavigationParentProperty =
            DependencyProperty.RegisterAttached(
                "NavigationParent",
                typeof(INavigationView),
                typeof(NavigationView),
                new FrameworkPropertyMetadata(
                    (INavigationView)null,
                    FrameworkPropertyMetadataOptions.Inherits
                )
            );

        /// <summary>
        /// 在子项中使用静态方法可以获得子项顶层继承控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        internal static NavigationView? GetNavigationView<T>(T item)
            where T : DependencyObject, INavigationViewItem
        {
            if (item.GetValue(NavigationParentProperty) is NavigationView navigationView)
            {
                return navigationView;
            }
            return null;
        }

        public Brush PaneBackground
        {
            get { return (Brush)GetValue(PaneBackgroundProperty); }
            set { SetValue(PaneBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PaneBackgroundProperty = DependencyProperty.Register(
            "PaneBackground",
            typeof(Brush),
            typeof(NavigationView),
            new PropertyMetadata(null)
        );




        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(NavigationView), new PropertyMetadata(null));



        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(NavigationView), new PropertyMetadata(null));


        
    }
}
