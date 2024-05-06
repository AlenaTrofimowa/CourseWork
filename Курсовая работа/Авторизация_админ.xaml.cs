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

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Авторизация_админ.xaml
    /// </summary>
    public partial class Авторизация_админ : Window
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();

        public Авторизация_админ()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //вынеси в общее окно
            var user = context.Users.SingleOrDefault(u => u.Password == Password.Password
            && u.Login == LoginUsernameTextBox.Text && u.Id_role == 1);

            if (user is null)
            {
                MessageBox.Show("Логин или пароль указан неправильно! Попробуйте снова");

                return;
            }

            MessageBox.Show("Администратор успешно вошел в систему");

            SessionHandler.UserId = user.Id;

            var fm1 = new Создание_отчетов();

            fm1.Show();

            Hide();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Window fm1 = new Авторизация_пользователь();

            fm1.Show();
            Hide();
        }
    }
}
