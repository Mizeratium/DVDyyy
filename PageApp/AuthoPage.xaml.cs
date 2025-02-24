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
using System.Xml.Linq;

namespace DVDyyy.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public AuthoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Авторизация и определение роли сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClEventAuto(object sender, RoutedEventArgs e)
        {
            try
            {
                var _sel = BD_Class.connection.Employee.Where(z => z.login == txbLogin.Text && z.password == txbPassword.Password).FirstOrDefault();
                if (_sel != null)
                {
                    if (_sel.id_role == 1)
                    {
                        NavigationService.Navigate(new PageApp.AdminMenuPage()); //Администратор
                    }
                    else if (_sel.id_role == 2)
                    {
                        NavigationService.Navigate(new PageApp.CashierPage()); //Кассир
                    }
                    else
                    {
                        NavigationService.Navigate(new PageApp.EmployeePage()); //Сотрудник зала
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
