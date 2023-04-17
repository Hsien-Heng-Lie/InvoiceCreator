namespace InvoiceCreator.Models
{
    public class TransactionsModel
    {
        public int Id { get; set; }

        public StudentModel Student { get; set; }

        public QuestionModel Question { get; set; }
    }
}
