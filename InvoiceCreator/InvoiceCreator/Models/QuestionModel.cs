namespace InvoiceCreator.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public QuestionDifficultyModel Difficulty { get; set; }

        public LevelUpModel LevelUp { get; set; }
    }
}
