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
    /// Логика взаимодействия для NewEmployeePage.xaml
    /// </summary>
    public partial class NewEmployeePage : Page
    {
        Employee employee = new Employee();
        public NewEmployeePage()
        {
            InitializeComponent();
            var collect = BD_Class.connection.Role.ToList();
            cmbRole.ItemsSource = collect;
            cmbRole.DisplayMemberPath = "title";
        }

        private void ClEventAddNewProduct(object sender, RoutedEventArgs e)
        {
            if (txbSurname.Text != "" && txbName.Text != "" && txbPatronymic.Text != "" && txbLogin.Text != "" && txbPassword.Text != "")
            {
                var selCombo = cmbRole.SelectedItem as Role;
                employee.surname = txbSurname.Text;
                employee.name = txbName.Text;
                employee.patronymic = txbPatronymic.Text;
                employee.id_role = selCombo.ID;
                employee.login = txbLogin.Text;
                employee.password = txbPassword.Text;
                BD_Class.connection.Employee.Add(employee);
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
