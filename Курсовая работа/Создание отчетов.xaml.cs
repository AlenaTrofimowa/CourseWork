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
using System.Windows.Shapes;

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Создание_отчетов.xaml
    /// </summary>
    public partial class Создание_отчетов : Window
    {
        public Создание_отчетов()
        {
            InitializeComponent();
        }


        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Window fm2 = new Отчет_по_продажам();
            fm2.Show();
            this.Hide();
        }


        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new MainWindow();
            taskWindow.Show();
            this.Hide();
        }
    }
}
