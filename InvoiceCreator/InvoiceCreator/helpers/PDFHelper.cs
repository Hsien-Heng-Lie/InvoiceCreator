using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using InvoiceCreator.Data;
using InvoiceCreator.Models;

namespace InvoiceCreator.Helpers
{
    public class PDFHelper
    {
        public static Document GeneratePDF(int StudentId)
        {
            List<TransactionsModel> transactions = DatabaseHandler.getStudentTransactions(StudentId);
            List<StudentModel> students = DatabaseHandler.getStudents();
            StudentModel student;
            student = students.Find(s => s.Id == StudentId);

            Document pdfDoc = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);

            Label label = new Label("YOU OWE ME @BBD", 0, 0, 504, 50, Font.HelveticaBold, 18, TextAlign.Center);
            page.Elements.Add(label);
            Line line = new Line(0,22,504, 22,width:2);
            page.Elements.Add(line);

            label = new Label("Bill To:", 0, 30, 504, 50, Font.Helvetica, 16, TextAlign.Left);
            page.Elements.Add(label);
            label = new Label("From:", 250, 30, 504, 50, Font.Helvetica, 16, TextAlign.Left);
            page.Elements.Add(label);
            line = new Line(0, 55, 504, 55, width: 1);
            page.Elements.Add(line);

            line = new Line(250, 55, 250, 100, width: 2);
            page.Elements.Add(line);

            label = new Label("Student Name: "+student.FirstName +" "+ student.LastName, 0, 60, 504, 50, Font.Helvetica, 16, TextAlign.Left);
            page.Elements.Add(label);

            label = new Label("YOU OWE ME @BDD", 260, 60, 504, 50, Font.Helvetica, 16, TextAlign.Left);
            page.Elements.Add(label);

            label = new Label("Transactions: ", 0, 120, 504, 50, Font.Helvetica, 16, TextAlign.Left);
            page.Elements.Add(label);
            Table2 table = new Table2(20, 140, 600, 400);
            Column2 col = table.Columns.Add(120);
            col.CellDefault.Align = TextAlign.Center;
            table.Columns.Add(120);
            table.Columns.Add(120);
            table.Columns.Add(90);

            Row2 row1 = table.Rows.Add(40, Font.Helvetica, 14, Grayscale.Black, Grayscale.LightGrey);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;

            row1.Cells.Add("Question");
            row1.Cells.Add("Level Up");
            row1.Cells.Add("Question Difficulty");
            row1.Cells.Add("Cost");

            transactions.ForEach(x => 
            {
                Row2 row2 = table.Rows.Add(20);
                Cell2 cell = row2.Cells.Add(x.Question.Description, Font.Helvetica, 12, Grayscale.Black, Grayscale.White, 1);
                row2.CellDefault.Align = TextAlign.Center;
                row2.CellDefault.VAlign = VAlign.Center;
                row2.Cells.Add(x.Question.LevelUp.CourseName);
                row2.Cells.Add(x.Question.Difficulty.DifficultyName);
                row2.Cells.Add("R "+ x.Question.Difficulty.Cost.ToString());
                
            });

            table.CellDefault.Padding.Value = 2.5f;
            table.CellSpacing = 5.0f;
            table.Border.Top.Color = RgbColor.Black;
            table.Border.Bottom.Color = RgbColor.Black;
            table.Border.Top.Width = 1.5f;
            table.Border.Bottom.Width = 1.5f;
            table.Border.Left.LineStyle = LineStyle.Solid;
            table.Border.Right.LineStyle = LineStyle.Solid;

            decimal totalBill = transactions.Sum(s => s.Question.Difficulty.Cost);
            label = new Label("Total Cost: R " + totalBill.ToString(), 0, 100, 504, 50, Font.Helvetica, 16, TextAlign.Left);
            page.Elements.Add(label);

            do
            {
                pdfDoc.Pages.Add(page);
                page.Elements.Add(table);
                table = table.GetOverflowRows();
                page = new Page();
            } while (table != null);

            
            return pdfDoc;
        }
    }
}