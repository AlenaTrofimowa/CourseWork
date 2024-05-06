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
using System.Data.Entity.Migrations;

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Характеристика_кольца1.xaml
    /// </summary>
    public partial class Характеристика_кольца1 : Window
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();
        public Product Product { get; set; }
        public Характеристика_кольца1(int productId)
        {
            InitializeComponent();
            Product = context.Products.SingleOrDefault(p => p.Id == productId);

            DataContext = this;
        }



        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new Кольца();
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
