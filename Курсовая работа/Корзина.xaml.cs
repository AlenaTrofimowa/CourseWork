using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Корзина.xaml
    /// </summary>
    public partial class Корзина : Window
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();
        public Корзина()
        {
            InitializeComponent();

            CartItems.ItemsSource = context.ShoppingCarts.Where(s => s.Id_user == SessionHandler.UserId && !s.Closed)
                .Select(s => new
                {
                    s.Product.name,
                    s.Count,
                    Price = s.Product.Price * s.Count,
                }).ToArray();
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new Каталог();
            taskWindow.Show();

            Hide();
        }

        private void oformlenie_pokypki_Click(object sender, RoutedEventArgs e)
        {
            var products = context.ShoppingCarts.Where(c => c.Id_user == SessionHandler.UserId).ToArray();

            if (products.Length == 0)
            {
                MessageBox.Show("Товаров в корзине нет! Сначала добавьте товары");
                return;
            }

            foreach (var product in products)
            {
                product.Closed = true;
            }

            context.ShoppingCarts.AddOrUpdate(products);

            MessageBox.Show("Покупка успешно оформлена! С нетерпением ждем вас снова");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Вы успешно вышли из приложения! =)");

            Application.Current.Shutdown();
          
        }
    }
}
