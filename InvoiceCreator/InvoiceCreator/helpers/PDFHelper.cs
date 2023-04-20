using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using InvoiceCreator.Data;
using InvoiceCreator.Models;

namespace InvoiceCreator.Helpers
{
    public class PDFHelper
    {
        public static Document GeneratePDF(int TransID)
        {
            Document pdfDoc = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);

            pdfDoc.Pages.Add(page);

            Label label = new Label("Hello", 0, 0, 504, 50, Font.HelveticaBold, 18, TextAlign.Center);
            page.Elements.Add(label);

            Table2 table = new Table2(0, 30, 800, 600);
            Column2 col = table.Columns.Add(240);
            col.CellDefault.Align = TextAlign.Center;
            table.Columns.Add(120);
            table.Columns.Add(90);

            Row2 row1 = table.Rows.Add(40, Font.Helvetica, 14, Grayscale.Black, Grayscale.LightGrey);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;

            row1.Cells.Add("Question");
            row1.Cells.Add("Question Difficulty");
            row1.Cells.Add("Cost");

            TransactionsModel transaction = DatabaseHandler.getTransactions().FirstOrDefault(t => t.Id == TransID);

            Row2 row2 = table.Rows.Add(20);
            Cell2 cell = row2.Cells.Add(transaction.Question.Description, Font.Helvetica, 12, Grayscale.Black, Grayscale.White, 1);
            row2.CellDefault.Align = TextAlign.Center;
            row2.CellDefault.VAlign = VAlign.Center;
            row2.Cells.Add(transaction.Question.Difficulty.DifficultyName);
            row2.Cells.Add(transaction.Question.Difficulty.Cost.ToString());

            table.CellDefault.Padding.Value = 2.5f;
            table.CellSpacing = 5.0f;
            table.Border.Top.Color = RgbColor.Black;
            table.Border.Bottom.Color = RgbColor.Black;
            table.Border.Top.Width = 1.5f;
            table.Border.Bottom.Width = 1.5f;
            table.Border.Left.LineStyle = LineStyle.Solid;
            table.Border.Right.LineStyle = LineStyle.Solid;

            page.Elements.Add(table);

            return pdfDoc;
        }
    }
}