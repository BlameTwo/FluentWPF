using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInstaller.ViewModels;

namespace WindowsInstaller.Views
{
    /// <summary>
    /// SearchView.xaml 的交互逻辑
    /// </summary>
    public partial class SearchView : Page
    {
        public SearchView()
        {
            InitializeComponent();
            this.DataContext = Register.GetService<SearchViewModel>();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var result = datagrid.SelectedItem;
        }
    }
}
