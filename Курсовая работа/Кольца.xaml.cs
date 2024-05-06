using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Contexts;

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Кольца.xaml
    /// </summary>
    public partial class Кольца : Window

        
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();

        public ObservableCollection<Product> Products { get; set; }
        public Кольца()
        {
            InitializeComponent();
            var products = context.Products.Where(p => p.Id_ProductCategories == 3)
                    .ToList();

            Products = new ObservableCollection<Product>(products);

            DataContext = this;


        }


        private void OpenProductDescription_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ((Button)sender).DataContext as Product;

           var window = new Характеристика_кольца1(selectedProduct.Id);

           window.Show();

           Hide();
        }

        private void OpenShopCart_Click(object sender, RoutedEventArgs e)
        {
            var window = new Корзина();

            window.Show();

            Close();

            //ибо Hide засоряет память
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Каталог();

            window.Show();

            Close();
        }
    }
}
