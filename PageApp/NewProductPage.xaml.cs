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
        Film film = new Film();
        public NewProductPage()
        {
            InitializeComponent();
            var collect = BD_Class.connection.Genre.ToList();
            cmbGenre.ItemsSource = collect;
            cmbGenre.DisplayMemberPath = "title";
            
        }

        private void ClEventAddNewProduct(object sender, RoutedEventArgs e)
        {
        
                if  (txbTitle.Text != "" && cmbGenre.SelectedItem != null && txbYearOfRelease.Text != "" && txbRentCost.Text != "")
                {
                    //переменная которая нужна для вытягивания айдишника из внешнего ключа, т.е в выпадающем списке названия жанров таблицы Жанр,
                    //а в таблице Фильм вместо жанра его айди
                    var selCombo = cmbGenre.SelectedItem as Genre;
                    film.title = txbTitle.Text.Trim();
                    film.id_genre = selCombo.ID; //айди = выбранный тайтл
                    film.year_of_release = Convert.ToDateTime(txbYearOfRelease.Text.Trim());
                    film.rental_cost = Convert.ToInt32(txbRentCost.Text.Trim());
                    BD_Class.connection.Film.Add(film); //добавление
                    BD_Class.connection.SaveChanges(); //сохранение
                    MessageBox.Show("Фильм добавлен");
                }
                else
                {
                    MessageBox.Show("Фильм не добавлен");
                }
          
        }
    }
}
