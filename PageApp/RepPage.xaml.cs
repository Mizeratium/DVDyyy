using DVDyyy.DB;
using Microsoft.Office.Interop.Word;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace DVDyyy.PageApp
{
    /// <summary>
    /// Логика взаимодействия для RepPage.xaml
    /// </summary>
    public partial class RepPage : System.Windows.Controls.Page
    {
        public RepPage()
        {
            InitializeComponent();
        }

        private void ClEventGenerateReport(object sender, RoutedEventArgs e)
        {
            var allFilms = BD_Class.connection.Film.ToList();
            var allClients = BD_Class.connection.Client.ToList();
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();
            foreach (var film in allFilms)
            {
                Word.Paragraph paragraph = document.Paragraphs.Add();
                Word.Range range = paragraph.Range;
                range.Text = film.title;
                //paragraph.set_Style("normal");
                range.InsertParagraphAfter();
                Word.Paragraph table = document.Paragraphs.Add();
                Word.Range tableRange = table.Range;
                Word.Table payments = document.Tables.Add(tableRange, allClients.Count()+1, 3);
                payments.Borders.InsideLineStyle = payments.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                payments.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = payments.Cell(1, 1).Range;
                cellRange.Text = "Дата";
                cellRange = payments.Cell(1, 2).Range;
                cellRange.Text = "Сумма";
                cellRange = payments.Cell(1, 3).Range;
                payments.Rows[1].Range.Bold = 1;
                payments.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                for (int i = 0; i < allClients.Count(); i++)
                {
                    var currentClient = allClients[i];
                    cellRange = payments.Cell(i + 2, 1).Range;
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    cellRange = payments.Cell(i +2, 3).Range;
                    cellRange.Text = currentClient.name;
                    cellRange = payments.Cell(i + 2, 3).Range;
                    cellRange.Text = film.title;
                }
                if (film != allFilms.LastOrDefault()) document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
            }
            application.Visible = true;
            document.SaveAs2(@"F:\\Рабочий стол\Test.docx");
            document.SaveAs2(@"F:\\Рабочий стол\Test.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }
    }
}
