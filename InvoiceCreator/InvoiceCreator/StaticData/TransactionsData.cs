using InvoiceCreator.Models;

namespace InvoiceCreator.StaticData
{
    public class TransactionsData
    {
        public static List<TransactionsModel> Transactions { 
            get
            {
                return listOfTransactions;
            }
        }

        private static List<TransactionsModel> listOfTransactions = new List<TransactionsModel>()
        {
            new TransactionsModel {
                Id=1,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },

            new TransactionsModel {
                Id=2,
                Question=new QuestionModel{Id=2,Description="What is your job?",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student=new StudentModel() {Id=2,FirstName="James",LastName="N",gradYear=DateTime.Now.Year},

            },

            new TransactionsModel {
                Id=3,
                Question=new QuestionModel{Id=3,Description="This is a question",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },
                },
                Student= new StudentModel() {Id=3,FirstName="John",LastName="B",gradYear=DateTime.Now.Year },
            },

            new TransactionsModel {
                Id=4,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },

            new TransactionsModel {
                Id=5,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },

            new TransactionsModel {
                Id=6,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },

            new TransactionsModel {
                Id=7,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
             new TransactionsModel {
                Id=8,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
              new TransactionsModel {
                Id=9,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
               new TransactionsModel {
                Id=10,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                new TransactionsModel {
                Id=11,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                 new TransactionsModel {
                Id=12,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                  new TransactionsModel {
                Id=13,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                   new TransactionsModel {
                Id=14,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                    new TransactionsModel {
                Id=15,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                     new TransactionsModel {
                Id=16,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                      new TransactionsModel {
                Id=17,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}
            },
                       new TransactionsModel {
                Id=18,
                Question=new QuestionModel{Id=1,Description="What is 2 plus 2",
                    Difficulty=new QuestionDifficultyModel{ Id=1,DifficultyName="Easy",cost=100.23M,DifficultyDescription="Your mom"},
                    LevelUp=new LevelUpModel{Id=1,CourseName="C#", Start=new DateTime(2022,02,03), End=new DateTime(2022,03,03) },

                },
                Student= new StudentModel() {Id=1,FirstName="Steven",LastName="Pinto",gradYear=DateTime.Now.Year}

            },
        };
    }
}
