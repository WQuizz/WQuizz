using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices;

public class WQuizzDBContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public WQuizzDBContext()
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreator != null)
        {
            if(!databaseCreator.CanConnect()) databaseCreator.Create();
            if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Quiz>().HasMany(e => e.Questions)
            .WithOne(e => e.Quiz)
            .HasForeignKey(e => e.QuizId)
            .HasPrincipalKey(e => e.Id);
        builder.Entity<Question>().HasMany(e => e.Answers)
            .WithOne(e => e.Question)
            .HasForeignKey(e => e.QuestionId)
            .HasPrincipalKey(e => e.Id);
        builder.Entity<Quiz>().HasData(
            new Quiz
            {
                QuizName = "Capital Cities around the World", IsApproved = true, Popularity = 0, Rating = 0,
                Difficulty = Difficulty.Easy, ThumbnailUrl = "https://geology.com/world/world-map.gif"
            },
            new Quiz
            {
                QuizName = "Chemical Symbols", IsApproved = true, Popularity = 0, Rating = 0,
                Difficulty = Difficulty.Medium,  ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Colour_18-col_PT_with_labels.png"
            }
        );
        builder.Entity<Question>().HasData(

            #region Capital Cities around the World Questions
            new Question
            {
                QuestionContent = "What is the capital of France?", QuizId = 1,
                QuestionImgUrl =
                    "https://static.vecteezy.com/system/resources/previews/008/726/860/original/map-of-france-outline-map-illustration-free-vector.jpg"
            },
            new Question
            {
                QuestionContent = "What is the capital of the USA?", QuizId = 1,
                QuestionImgUrl =
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Map_of_USA_with_state_names.svg/langhu-800px-Map_of_USA_with_state_names.svg.png"
            },
            new Question
            {
                QuestionContent = "What is the capital of Japan?", QuizId = 1,
                QuestionImgUrl = 
                    "https://cdn.pixabay.com/photo/2013/05/22/18/00/japan-112722_1280.jpg"
            },
            new Question
            {
                QuestionContent = "What is the capital of Denmark?", QuizId = 1,
                QuestionImgUrl = "https://static.vecteezy.com/system/resources/previews/019/476/194/original/denmark-map-in-europe-zoom-version-icons-showing-denmark-location-and-flags-vector.jpg"
            },
            #endregion
            
            #region Chemical Symbols Questions
            
            new Question
            {
                QuestionContent = "What is the chemical symbol of Uranium", QuizId = 2, 
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/HEUraniumC.jpg/1200px-HEUraniumC.jpg"
            },
            new Question
            {
                QuestionContent = "What is the chemical symbol of Helium?", QuizId = 2,
                QuestionImgUrl = "https://static.wikia.nocookie.net/fortnite/images/d/da/Balloons_%28Old%29_-_Item_-_Fortnite.png/revision/latest?cb=20200717131102"
            },
            new Question
            {
                QuestionContent = "What is the chemical symbol of Magnesium?", QuizId = 2,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/CSIRO_ScienceImage_2893_Crystalised_magnesium.jpg"
            },
            new Question
            {
                QuestionContent = "What is the chemical symbol of Gold?", QuizId = 2,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/6/69/Gold_nugget_%28Australia%29_4_%2816848647509%29.jpg"
            },
            new Question
            {
                QuestionContent = "What is the chemical symbol of Silver?", QuizId = 2,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Silver_crystal.jpg/1200px-Silver_crystal.jpg"
            }
            
            #endregion
        );
        builder.Entity<Answer>().HasData(

            #region Capital of France Answers
            new Answer
            {
                AnswerContent = "Berlin", QuestionId = 1, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Orleans", QuestionId = 1, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Paris", QuestionId = 1, IsCorrect = true
            },
            new Answer
            {
                AnswerContent = "Brussels", QuestionId = 1, IsCorrect = false
            },
            #endregion

            #region Capital of USA Answers
            
            new Answer
            {
                AnswerContent = "Houston", QuestionId = 2, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "New York", QuestionId = 2, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Dallas", QuestionId = 2, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Dallas", QuestionId = 2, IsCorrect = false
            },
            #endregion

            #region Capital of Japan Answers

            new Answer
            {
                AnswerContent = "Kyoto", QuestionId = 3, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Tokyo", QuestionId = 3, IsCorrect = true
            },
            new Answer
            {
                AnswerContent = "Okinawa", QuestionId = 3, IsCorrect = true
            },
            new Answer
            {
                AnswerContent = "Yokohama", QuestionId = 3, IsCorrect = false
            },
            #endregion

            #region Capital of Denmark Answer

            new Answer
            {
                AnswerContent = "Copenhagen", QuestionId = 4, IsCorrect = true
            },
            new Answer
            {
                AnswerContent = "Arhus", QuestionId = 4, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Aalborg", QuestionId = 4, IsCorrect = false
            },
            new Answer
            {
                AnswerContent = "Frederiksberg", QuestionId = 4, IsCorrect = false
            },

            #endregion

            #region Chemical Symbol of Uranium Answers

            new Answer
            {
                AnswerContent = "U", IsCorrect = true, QuestionId = 5
            },
            new Answer
            {
                AnswerContent = "Ur", IsCorrect = false, QuestionId = 5
            },
            new Answer
            {
                AnswerContent = "Ua", IsCorrect = false, QuestionId = 5
            },
            new Answer
            {
                AnswerContent = "An", IsCorrect = false, QuestionId = 5
            },

            #endregion

            #region Chemical Symbol of Helium Answers

            new Answer
            {
                AnswerContent = "H", IsCorrect = false, QuestionId = 6
            },
            new Answer
            {
                AnswerContent = "He", IsCorrect = true, QuestionId = 6
            },
            new Answer
            {
                AnswerContent = "Hl", IsCorrect = false, QuestionId = 6
            },
            new Answer
            {
                AnswerContent = "Hx", IsCorrect = false, QuestionId = 6
            },

            #endregion

            #region Chemical Symbol of Magnesium Answers

            new Answer
            {
                AnswerContent = "M", IsCorrect = false, QuestionId = 7
            },
            new Answer
            {
                AnswerContent = "Ma", IsCorrect = false, QuestionId = 7
            },
            new Answer
            {
                AnswerContent = "Mg", IsCorrect = true, QuestionId = 7
            },
            new Answer
            {
                AnswerContent = "Na", IsCorrect = false, QuestionId = 7
            },

            #endregion

            #region Chemical Symbol of Gold

            new Answer
            {
                AnswerContent = "G", IsCorrect = false, QuestionId = 8
            },
            new Answer
            {
                AnswerContent = "Go", IsCorrect = false, QuestionId = 8
            },
            new Answer
            {
                AnswerContent = "Au", IsCorrect = true, QuestionId = 8
            },
            new Answer
            {
                AnswerContent = "Ar", IsCorrect = false, QuestionId = 8
            },

            #endregion

            #region Chemical Symbol of Silver

            new Answer
            {
                AnswerContent = "S", IsCorrect = false, QuestionId = 9
            },
            new Answer
            {
                AnswerContent = "Si", IsCorrect = false, QuestionId = 9
            },
            new Answer
            {
                AnswerContent = "Ar", IsCorrect = false, QuestionId = 9
            },
            new Answer
            {
                AnswerContent = "Ag", IsCorrect = true, QuestionId = 9
            }

                #endregion
        );
    }
}