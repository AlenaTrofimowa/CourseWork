using Microsoft.Win32;
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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Курсовая_работа
{
    /// <summary>
    /// Логика взаимодействия для Отчет_по_продажам.xaml
    /// </summary>
    public partial class Отчет_по_продажам : Window
    {
        KyrsovaiaEntities context = new KyrsovaiaEntities();
        public Отчет_по_продажам()
        {
            InitializeComponent();
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Window taskWindow = new Создание_отчетов();
            taskWindow.Show();
            this.Hide();
        }

        private void SaveExcelReport_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];
            Excel.Range range = worksheet.UsedRange;

            var products = context.ShoppingCarts.GroupBy(s => s.Product)
                      .Select(s => new
                      {
                          s.Key,
                          Count = s.Sum(p => p.Count)
                      }).ToArray();

            for (int i = 0, row = 1; i < products.Length; i++, row++)
            {
                var product = products[i];

                range[row, 1].Value2 = product.Key.name;
                range[row, 2].Value2 = product.Count;
                range[row, 3].Value2 = product.Key.Price;
                range[row, 4].Value2 = product.Key.Price * product.Count;
            }

            workbook.SaveAs("F:\\Отчет_по_продажам.xlsx");

            MessageBox.Show("Отчет успешно был добавлен в Excel");

            app.Quit();
        }

        private void SaveWordReport_Click(object sender, RoutedEventArgs e)
        {
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Add();
            Word.Paragraph paragraph = doc.Paragraphs.Add();

            var products = context.ShoppingCarts.GroupBy(s => s.Product)
                   .Select(s => new
                   {
                       s.Key,
                       Count = s.Sum(p => p.Count)
                   }).ToArray();

            for (int i = 0, row = 1; i < products.Length; i++, row++)
            {
                var product = products[i];
            }

            Word.Table table = doc.Tables.Add(paragraph.Range, products.Length % 3 == 0 ? products.Length / 3 : products.Length / 3 + 1, 3);
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Word.Cell cell = table.Cell(1, 1);

            foreach (var product in products)
            {
                cell.Range.Text = $"\n{product.Key.name}\n{product.Count}\n{product.Key.Price}\n{product.Key.Price * product.Count}";

                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cell = cell.Next;
            }

            doc.SaveAs2("F:\\Отчет_по_продажам.docx");

            MessageBox.Show("Отчет успешно был добавлен в Word");

            app.Quit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно вышли из приложения! =)");

            Application.Current.Shutdown();
        }
    }
}
