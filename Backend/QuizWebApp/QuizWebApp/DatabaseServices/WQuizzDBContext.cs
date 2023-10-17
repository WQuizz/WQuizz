using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices;

public class WQuizzDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    public WQuizzDBContext()
    {
        if(Database.IsRelational()) Database.Migrate();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
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
                Id = 1,
                QuizName = "Capital Cities around the World", IsApproved = true, Popularity = 0, Rating = 0,
                Difficulty = Difficulty.Easy, ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Prague_%286365119737%29.jpg/1920px-Prague_%286365119737%29.jpg"
            },
            new Quiz
            {
                Id = 2,
                QuizName = "Chemical Symbols", IsApproved = true, Popularity = 0, Rating = 0,
                Difficulty = Difficulty.Medium,  ThumbnailUrl = "https://i.pinimg.com/originals/de/54/d3/de54d3e8700cbb87d534844531ae5b71.png"
            },
            new Quiz
            {
                Id = 3,
                QuizName = "Retro Gaming", IsApproved = true, Popularity = 0, Rating = 0,
                ThumbnailUrl = "https://as2.ftcdn.net/v2/jpg/05/59/01/05/1000_F_559010542_cXULDCcdcVwWCcf0DcE7V3QhCQO44Ryh.jpg",
                Difficulty = Difficulty.Hard,
            },
            new Quiz
            {
                Id = 4,
                QuizName = "Bionicle Lore", IsApproved = true, Popularity = 0, Rating = 0,
                ThumbnailUrl = "https://biosector01.com/w/images/bs01/0/0e/Toa_Mata_Sets.jpg",
                Difficulty = Difficulty.Hard,
            }
        );
        builder.Entity<Question>().HasData(

            #region Capital Cities around the World Questions
            new Question
            {
                Id = 1,
                QuestionContent = "What is the capital of France?", QuizId = 1,
                QuestionImgUrl =
                    "https://static.vecteezy.com/system/resources/previews/008/726/860/original/map-of-france-outline-map-illustration-free-vector.jpg"
            },
            new Question
            {
                Id = 2,
                QuestionContent = "What is the capital of the USA?", QuizId = 1,
                QuestionImgUrl =
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Map_of_USA_with_state_names.svg/langhu-800px-Map_of_USA_with_state_names.svg.png"
            },
            new Question
            {
                Id = 3,
                QuestionContent = "What is the capital of Japan?", QuizId = 1,
                QuestionImgUrl = 
                    "https://cdn.pixabay.com/photo/2013/05/22/18/00/japan-112722_1280.jpg"
            },
            new Question
            {
                Id = 4,
                QuestionContent = "What is the capital of Denmark?", QuizId = 1,
                QuestionImgUrl = "https://static.vecteezy.com/system/resources/previews/019/476/194/original/denmark-map-in-europe-zoom-version-icons-showing-denmark-location-and-flags-vector.jpg"
            },
            #endregion
            
            #region Chemical Symbols Questions
            
            new Question
            {
                Id = 5,
                QuestionContent = "What is the chemical symbol of Uranium", QuizId = 2, 
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/HEUraniumC.jpg/1200px-HEUraniumC.jpg"
            },
            new Question
            {
                Id = 6,
                QuestionContent = "What is the chemical symbol of Helium?", QuizId = 2,
                QuestionImgUrl = "https://static.wikia.nocookie.net/fortnite/images/d/da/Balloons_%28Old%29_-_Item_-_Fortnite.png/revision/latest?cb=20200717131102"
            },
            new Question
            {
                Id = 7,
                QuestionContent = "What is the chemical symbol of Magnesium?", QuizId = 2,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/CSIRO_ScienceImage_2893_Crystalised_magnesium.jpg"
            },
            new Question
            {
                Id = 8,
                QuestionContent = "What is the chemical symbol of Gold?", QuizId = 2,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/6/69/Gold_nugget_%28Australia%29_4_%2816848647509%29.jpg"
            },
            new Question
            {
                Id = 9,
                QuestionContent = "What is the chemical symbol of Silver?", QuizId = 2,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Silver_crystal.jpg/1200px-Silver_crystal.jpg"
            }
            
            #endregion
        );
        builder.Entity<Answer>().HasData(

            #region Capital of France Answers
            new Answer
            {
                Id = 1,
                AnswerContent = "Berlin", QuestionId = 1, IsCorrect = false
            },
            new Answer
            {
                Id = 2,
                AnswerContent = "Orleans", QuestionId = 1, IsCorrect = false
            },
            new Answer
            {
                Id = 3,
                AnswerContent = "Paris", QuestionId = 1, IsCorrect = true
            },
            new Answer
            {
                Id = 4,
                AnswerContent = "Brussels", QuestionId = 1, IsCorrect = false
            },
            #endregion

            #region Capital of USA Answers
            
            new Answer
            {
                Id = 5,
                AnswerContent = "Houston", QuestionId = 2, IsCorrect = false
            },
            new Answer
            {
                Id = 6,
                AnswerContent = "New York", QuestionId = 2, IsCorrect = false
            },
            new Answer
            {
                Id = 7,
                AnswerContent = "Dallas", QuestionId = 2, IsCorrect = false
            },
            new Answer
            {
                Id = 8,
                AnswerContent = "Washington, D.C", QuestionId = 2, IsCorrect = true
            },
            #endregion

            #region Capital of Japan Answers

            new Answer
            {
                Id = 9,
                AnswerContent = "Kyoto", QuestionId = 3, IsCorrect = false
            },
            new Answer
            {
                Id = 10,
                AnswerContent = "Tokyo", QuestionId = 3, IsCorrect = true
            },
            new Answer
            {
                Id = 11,
                AnswerContent = "Okinawa", QuestionId = 3, IsCorrect = false
            },
            new Answer
            {
                Id = 12,
                AnswerContent = "Yokohama", QuestionId = 3, IsCorrect = false
            },
            #endregion

            #region Capital of Denmark Answer

            new Answer
            {
                Id = 13,
                AnswerContent = "Copenhagen", QuestionId = 4, IsCorrect = true
            },
            new Answer
            {
                Id = 14,
                AnswerContent = "Arhus", QuestionId = 4, IsCorrect = false
            },
            new Answer
            {
                Id = 15,
                AnswerContent = "Aalborg", QuestionId = 4, IsCorrect = false
            },
            new Answer
            {
                Id = 16,
                AnswerContent = "Frederiksberg", QuestionId = 4, IsCorrect = false
            },

            #endregion

            #region Chemical Symbol of Uranium Answers

            new Answer
            {
                Id = 17,
                AnswerContent = "U", IsCorrect = true, QuestionId = 5
            },
            new Answer
            {
                Id = 18,
                AnswerContent = "Ur", IsCorrect = false, QuestionId = 5
            },
            new Answer
            {
                Id = 19,
                AnswerContent = "Ua", IsCorrect = false, QuestionId = 5
            },
            new Answer
            {
                Id = 20,
                AnswerContent = "An", IsCorrect = false, QuestionId = 5
            },

            #endregion

            #region Chemical Symbol of Helium Answers

            new Answer
            {
                Id = 21,
                AnswerContent = "H", IsCorrect = false, QuestionId = 6
            },
            new Answer
            {
                Id = 22,
                AnswerContent = "He", IsCorrect = true, QuestionId = 6
            },
            new Answer
            {
                Id = 23,
                AnswerContent = "Hl", IsCorrect = false, QuestionId = 6
            },
            new Answer
            {
                Id = 24,
                AnswerContent = "Hx", IsCorrect = false, QuestionId = 6
            },

            #endregion

            #region Chemical Symbol of Magnesium Answers

            new Answer
            {
                Id = 25,
                AnswerContent = "M", IsCorrect = false, QuestionId = 7
            },
            new Answer
            {
                Id = 26,
                AnswerContent = "Ma", IsCorrect = false, QuestionId = 7
            },
            new Answer
            {
                Id = 27,
                AnswerContent = "Mg", IsCorrect = true, QuestionId = 7
            },
            new Answer
            {
                Id = 28,
                AnswerContent = "Na", IsCorrect = false, QuestionId = 7
            },

            #endregion

            #region Chemical Symbol of Gold

            new Answer
            {
                Id = 29,
                AnswerContent = "G", IsCorrect = false, QuestionId = 8
            },
            new Answer
            {
                Id = 30,
                AnswerContent = "Go", IsCorrect = false, QuestionId = 8
            },
            new Answer
            {
                Id = 31,
                AnswerContent = "Au", IsCorrect = true, QuestionId = 8
            },
            new Answer
            {
                Id = 32,
                AnswerContent = "Ar", IsCorrect = false, QuestionId = 8
            },

            #endregion

            #region Chemical Symbol of Silver

            new Answer
            {
                Id = 33,
                AnswerContent = "S", IsCorrect = false, QuestionId = 9
            },
            new Answer
            {
                Id = 34,
                AnswerContent = "Si", IsCorrect = false, QuestionId = 9
            },
            new Answer
            {
                Id = 35,
                AnswerContent = "Ar", IsCorrect = false, QuestionId = 9
            },
            new Answer
            {
                Id = 36,
                AnswerContent = "Ag", IsCorrect = true, QuestionId = 9
            }

                #endregion
        );
    }
}