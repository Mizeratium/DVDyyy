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
    /// Логика взаимодействия для NewClientPae.xaml
    /// </summary>
    public partial class NewClientPae : Page
    {
        Client client = new Client();
        public NewClientPae()
        {
            InitializeComponent();
        }

        private void ClEventAddNewProduct(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text != "" && txbName.Text != "" && txbPatronymic.Text != "" && txbPhoneNumber.Text != "")
            {
                client.surname = txbSurname.Text;
                client.name = txbName.Text;
                client.patronymic = txbPatronymic.Text;
                client.phone = txbPhoneNumber.Text;
                BD_Class.connection.Client.Add(client);
                BD_Class.connection.SaveChanges();
                MessageBox.Show("Клиент добавлен");
            }
            else
            {
                MessageBox.Show("Клиент не добавлен");
            }
        }
    }
}
