using InvoiceCreator.Models;
using System.Data;
using System.Data.SqlClient;

namespace InvoiceCreator.Data
{
    public static class DatabaseHandler
    {
        private static string connectionString = @"Data Source=HSIENL\SQLEXPRESS; Database=Invoice_Creator;Integrated Security = True;";

        public static List<StudentModel> getStudents()
        {
            List<StudentModel> listOfStudents = new List<StudentModel>();

            string sql = "SELECT * FROM dbo.Student";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var student = new StudentModel();
                        student.Id = Convert.ToInt32(reader["Id"]);
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.Email = reader["Email"].ToString();
                        student.gradYear = Convert.ToDateTime(reader["GradYear"]).Year;

                        listOfStudents.Add(student);
                    }

                    cnn.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return listOfStudents;
        }

        public static List<LevelUpModel> getLevelUps()
        {
            List<LevelUpModel> listOfLevelUps = new List<LevelUpModel>();

            string sql = "SELECT * FROM dbo.LevelUp";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var levelUp = new LevelUpModel();

                        levelUp.Id = Convert.ToInt32(reader["Id"]);
                        levelUp.CourseName = reader["Name"].ToString();
                        levelUp.Start = Convert.ToDateTime(reader["StartDate"]);
                        levelUp.End = Convert.ToDateTime(reader["EndDate"]);

                        listOfLevelUps.Add(levelUp);
                    }

                    cnn.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return listOfLevelUps;
        }


        public static List<QuestionDifficultyModel> getQuestionDifficulties()
        {
            List<QuestionDifficultyModel> listOfQuestionDifficulties = new List<QuestionDifficultyModel>();

            string sql = "SELECT * FROM dbo.QuestionDifficulty";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var questionDifficulty = new QuestionDifficultyModel();

                        questionDifficulty.Id = Convert.ToInt32(reader["Id"]);
                        questionDifficulty.DifficultyName = reader["Name"].ToString();
                        questionDifficulty.DifficultyDescription = reader["Description"].ToString();
                        questionDifficulty.Cost = Convert.ToDecimal(reader["Cost"]);

                        listOfQuestionDifficulties.Add(questionDifficulty);
                    }

                    cnn.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return listOfQuestionDifficulties;
        }

        public static List<QuestionModel> getQuestions()
        {
            List<QuestionModel> listOfQuestions = new List<QuestionModel>();
            List<QuestionDifficultyModel> listOfQuestionDifficulties = getQuestionDifficulties();
            List<LevelUpModel> listOfLevelUps = getLevelUps();

            string sql = "SELECT * FROM dbo.Question";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var question = new QuestionModel();

                        question.Id = Convert.ToInt32(reader["Id"]);
                        question.Description = reader["Description"].ToString();
                        question.Difficulty = listOfQuestionDifficulties.Find(difficulty => difficulty.Id.Equals(reader["QuestionDifficultyId"]));
                        question.LevelUp = listOfLevelUps.Find(levelup => levelup.Id.Equals(reader["LevelUpId"]));

                        listOfQuestions.Add(question);
                    }

                    cnn.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return listOfQuestions;
        }

        public static List<TransactionsModel> getTransactions()
        {
            List<TransactionsModel> listOfTransactions = new List<TransactionsModel>();
            List<QuestionModel> listOfQuestions = getQuestions();
            List<StudentModel> listOfStudents = getStudents();

            string sql = "SELECT * FROM [Invoice_Creator].[dbo].[Transaction]";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var transaction = new TransactionsModel();

                        transaction.Id = Convert.ToInt32(reader["Id"]);
                        transaction.Student = listOfStudents.Find(student => student.Id.Equals(reader["StudentId"]));
                        transaction.Question = listOfQuestions.Find(question => question.Id.Equals(reader["QuestionId"]));

                        listOfTransactions.Add(transaction);
                    }

                    cnn.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return listOfTransactions;
        }

        public static void addQuestion(string studentId, string difficultyId, string levelUpId, string question)
        {

            string sql = "DECLARE @studentId INT =" + studentId
                + ",@diffcultyId INT =" + difficultyId
                + ",@question VARCHAR(500) =" + @"'" + question + @"'" 
                + @"INSERT INTO [dbo].[Question]
                    ([Description],
                    [QuestionDifficultyId],
                    [LevelUpId])
                    VALUES
                    (@question
                    ,@diffcultyId
                    ,@studentId)

                    DECLARE @questionId INT = SCOPE_IDENTITY()

                    INSERT INTO [dbo].[Transaction]
                    ([QuestionId]
                    ,[StudentId])
                    VALUES
                    (@questionId
                    ,@studentId) "
                ;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
