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
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        public int pageNum = 1;
        List<Film> listProd = BD_Class.connection.Film.ToList();
        public ProductsListPage()
        {
            InitializeComponent();
            
            int pagesCount = (listProd.Count / 5) % 1 > 0 ? listProd.Count / 5 + 1 : listProd.Count / 5;
            navigatePanel.Children.Clear();
            if (pageNum > 1)
            {
                Button button = new Button();
                button.Content = "<";
                button.Click += ClEvent;
                navigatePanel.Children.Add(button);
            }

            for (int i = 1; i <= pagesCount; i++)
            {
                Button button = new Button();
                button.Content = i.ToString();
                button.Click += ClEvent;
                navigatePanel.Children.Add(button);
            }

            if (pageNum > pagesCount)
            {
                Button button = new Button();
                button.Content = ">";
                button.Click += ClEvent;
                navigatePanel.Children.Add(button);
            }
            ProdList.ItemsSource = listProd.Skip((pageNum-1)*5).Take(5).ToList();
           
            
        }
        private void ClEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content.ToString() == "<")
            {
                pageNum -= 1;
            }
            else if (btn.Content.ToString() == ">")
            {
                pageNum += 1;
            }
            else
            {
                pageNum = int.Parse(btn.Content.ToString());
            }
           FillLV(pageNum);



        }
        public void FillLV( int pageNum)
        {
            ProdList.ItemsSource =listProd.Skip((pageNum-1)*5).Take(5).ToList();
        }
    }
}
