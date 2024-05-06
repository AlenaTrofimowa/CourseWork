using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Характеристика_букета1.xaml
    /// </summary>
    public partial class Характеристика_букета1 : Window
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();
        public Product Product { get; set; }
        public Характеристика_букета1(int productId)
        {
            InitializeComponent();
            Product = context.Products.SingleOrDefault(p => p.Id == productId);

            DataContext = this;
        }



        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new Букет();
            taskWindow.Show();
            this.Hide();
        }

        private void Rorzina_Click(object sender, RoutedEventArgs e)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == SessionHandler.UserId);

            var cart = context.ShoppingCarts.SingleOrDefault(s => s.Id_product == Product.Id && s.Id_user == user.Id);

            if (cart is null)
            {
                user.ShoppingCarts.Add(new ShoppingCart()
                {
                    Id_product = Product.Id,
                    User = user,
                });
            }
            else
            {
                cart.Count++;
            }

            context.Users.AddOrUpdate(user);

            context.SaveChanges();
        }
    }
}
