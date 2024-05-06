using Katalog_Byket;
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
    /// Логика взаимодействия для Каталог.xaml
    /// </summary>
    public partial class Каталог : Window
    {

        public Каталог()
        {
            InitializeComponent();

        }

        private void Byket_Click(object sender, RoutedEventArgs e)
        {
            {
                Window fm1 = new Букет();
                fm1.Show();
                this.Hide();
            }

        }

        private void Platie_Click(object sender, RoutedEventArgs e)
        {
            {
                Window fm1 = new Платье();
                fm1.Show();
                this.Hide();
            }
            

        }

        private void Tyfli_Click(object sender, RoutedEventArgs e)
        {
            {
                Window fm1 = new Туфли();
                fm1.Show();
                this.Hide();
            }

        }

        private void Fata_Click(object sender, RoutedEventArgs e)
        {
            {
                Window fm1 = new Фата();
                fm1.Show();
                this.Hide();
            }

        }

        private void Tiara_Click(object sender, RoutedEventArgs e)
        {
            {
                Window fm1 = new Тиара();
                fm1.Show();
                this.Hide();
            }

        }

        private void kolza_Click(object sender, RoutedEventArgs e)
        {
            {
                Window fm1 = new Кольца();
                fm1.Show();
                this.Hide();
            }

        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new MainWindow();
            taskWindow.Show();
            this.Hide();

        }
    }
}
