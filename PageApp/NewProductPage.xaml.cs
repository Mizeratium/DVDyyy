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
    /// Логика взаимодействия для NewProductPage.xaml
    /// </summary>
    public partial class NewProductPage : Page
    {
        public NewProductPage()
        {
            InitializeComponent();
            var collect = BD_Class.connection.Genre.ToList();
            cmbGenre.ItemsSource = collect;
            cmbGenre.DisplayMemberPath = "title";
        }

        private void ClEventAddNewProduct(object sender, RoutedEventArgs e)
        {

        }
    }
}
