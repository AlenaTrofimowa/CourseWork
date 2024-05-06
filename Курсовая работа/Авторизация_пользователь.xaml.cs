using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Авторизация_пользователь.xaml
    /// </summary>
    public partial class Авторизация_пользователь : Window
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();
        public Авторизация_пользователь()
        {
            InitializeComponent();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //вынеси в общее окно
            var user = context.Users.SingleOrDefault(u => u.Password == LoginPasswordTextBox.Password && u.Login == LoginUsernameTextBox.Text);

            if (user is null)
            {
                MessageBox.Show("Логин или пароль указан неправильно! Попробуйте снова");

                return;
            }

            MessageBox.Show("Пользователь успешно вошел в систему");

            SessionHandler.UserId = user.Id;

            var fm1 = new Каталог();

            fm1.Show();

            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window fm1 = new Авторизация_админ();
            fm1.Show();
            this.Hide();
        }
    }
}
