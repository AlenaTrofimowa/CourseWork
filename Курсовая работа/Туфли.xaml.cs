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

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Туфли.xaml
    /// </summary>
    public partial class Туфли : Window
    {

        KyrsovaiaEntities context = new KyrsovaiaEntities();

        public ObservableCollection<Product> Products { get; set; }
        public Туфли()
        {
            InitializeComponent();
            var products = context.Products.Where(p => p.Id_ProductCategories == 6)
                    .ToList();

            Products = new ObservableCollection<Product>(products);

            DataContext = this;


        }


        private void OpenProductDescription_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ((Button)sender).DataContext as Product;

            var window = new Характеристика_туфли1(selectedProduct.Id);

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
