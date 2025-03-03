using DVDyyy.DB;
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
    /// Логика взаимодействия для ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        public ClientsListPage()
        {
            InitializeComponent();
            ClientsList.ItemsSource = BD_Class.connection.Client.ToList();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text != null)
            {
                ClientsList.ItemsSource = BD_Class.connection.Client.Where(z => z.surname.Contains(txbSearch.Text) || z.name.Contains(txbSearch.Text) || z.patronymic.Contains(txbSearch.Text)).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
