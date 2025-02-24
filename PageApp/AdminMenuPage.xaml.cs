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

namespace DVDyyy.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.ProductsListPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.ProductsListPage());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.NewProductPage());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.ClientsListPage());
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.NewClientPae());
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.EmployeersListPage());
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new PageApp.NewEmployeePage());
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            //Отчеты
        }
    }
}
