using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using QuizWebApp.Models;

namespace QuizWebApp.DatabaseServices;

public class WQuizzDBContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public WQuizzDBContext()
    {
        if(Database.IsRelational()) Database.Migrate();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
        optionsBuilder.UseNpgsql(connectionString);
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
        
        builder.Entity<UserProfile>()
            .HasOne(userProfile => userProfile.User)
            .WithOne(user => user.UserProfile)
            .HasForeignKey<UserProfile>(userProfile => userProfile.UserId);
        
        builder.Entity<Quiz>().HasData(
            new Quiz
            {
                Id = 1,
                QuizName = "Capital Cities around the World", IsApproved = true, Popularity = 100, Rating = 100,
                Difficulty = Difficulty.Easy, CategoryType = Category.Cities, ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Prague_%286365119737%29.jpg/1920px-Prague_%286365119737%29.jpg"
            },
            new Quiz
            {
                Id = 2,
                QuizName = "Chemical Symbols", IsApproved = true, Popularity = new Random().Next(50,100), Rating = new Random().Next(50,100),
                Difficulty = Difficulty.Medium, CategoryType = Category.Chemistry, ThumbnailUrl = "https://i.pinimg.com/originals/de/54/d3/de54d3e8700cbb87d534844531ae5b71.png"
            },
            new Quiz
            {
                Id = 3,
                QuizName = "Retro Gaming", IsApproved = true, Popularity = new Random().Next(50,100), Rating = new Random().Next(50,100),
                ThumbnailUrl = "https://as2.ftcdn.net/v2/jpg/05/59/01/05/1000_F_559010542_cXULDCcdcVwWCcf0DcE7V3QhCQO44Ryh.jpg",
                Difficulty = Difficulty.Hard, CategoryType = Category.Entertainment
            },
            new Quiz
            {
                Id = 4,
                QuizName = "Bionicle Lore", IsApproved = true, Popularity = new Random().Next(50,100), Rating = new Random().Next(50,100),
                ThumbnailUrl = "https://biosector01.com/w/images/bs01/0/0e/Toa_Mata_Sets.jpg",
                Difficulty = Difficulty.Hard, CategoryType = Category.Entertainment
            },
            new Quiz
            {
                Id = 5,
                QuizName = "All about Animals!", IsApproved = true, Popularity = new Random().Next(50,100), Rating = new Random().Next(50,100),
                ThumbnailUrl = "https://static.wikia.nocookie.net/mythology/images/f/f7/Animal_Collage.jpg/revision/latest/scale-to-width-down/600?cb=20210219055843",
                Difficulty = Difficulty.Medium, CategoryType = Category.Animals
            },
            new Quiz
            {
                Id = 6,
                QuizName = "National Dishes Around the World",
                IsApproved = true,
                Popularity = new Random().Next(50, 100),
                Rating = new Random().Next(50, 100),
                ThumbnailUrl = "https://www.cactuslanguage.com/wp-content/uploads/2022/09/table-of-food.jpg",
                Difficulty = Difficulty.Medium,
                CategoryType = Category.Food
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
            },
            
            #endregion

            #region All about Animals! Questions

            new Question
            {
                Id = 10,
                QuestionContent = "Which of these animals is known for its ability to change color to camouflage itself?", QuizId = 5,
                QuestionImgUrl = "https://static.spokanecity.org/photos/2019/09/30/leaf-colors/16x10/Full/leaf-colors.jpg"
            },
            new Question
            {
                Id = 11,
                QuestionContent ="What is the largest species of shark?", QuizId = 5,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/5/59/Caribbean_reef_shark.jpg"
            },
            new Question
            {
                Id = 12,
                QuestionContent = "What is the largest land animal on Earth?", QuizId = 5,
                QuestionImgUrl = "https://i.ytimg.com/vi/KhfCgkJmg8M/maxresdefault.jpg"
            },
            new Question
            {
                Id = 13,
                QuestionContent = "Which of the following animals is a marsupial?", QuizId = 5,
                QuestionImgUrl = "https://cdn.britannica.com/07/154807-050-3226C065/species-Wombat-wombats-wombat-population-Tasmania-Australia.jpg"
            },
            new Question
            {
                Id = 14,
                QuestionContent = "What is the national bird of the United States?", QuizId = 5,
                QuestionImgUrl = "https://www.usnews.com/object/image/0000016f-8c62-d408-a9ef-9ffe94a60000/200115bcusaprofile-editorial.usa.profile.jpg?update-time=1578608368142&size=superhero-medium"
            },

            #endregion

            #region Bionicle Lore Questions

            new Question
            {
                Id = 15,
                QuestionContent = "What are the three virtues of the Bionicle Universe?", QuizId = 4,
                QuestionImgUrl = "https://biosector01.com/w/images/bs01/b/b6/BIONICLE_Logo.png"
            },
            
            new Question
            {
                Id = 16,
                QuestionContent = "When was Bionicle first released?", QuizId = 4,
                QuestionImgUrl = "https://biosector01.com/w/images/bs01/0/0e/Toa_Mata_Sets.jpg"
            },
            
            new Question
            {
                Id = 17,
                QuestionContent = "What's the name of the island Bionicle first took place in?", QuizId = 4,
                QuestionImgUrl = "https://biosector01.com/w/images/bs01/a/a2/CGI_Mata_Nui_%28Island%29.jpg"
            },
            
            new Question
            {
                Id = 18,
                QuestionContent = "What are wild animals in the Bionicle universe called?", QuizId = 4,
                QuestionImgUrl = "https://biosector01.com/w/images/bs01/b/b2/Promo_Art_Rahi.png"
            },

            #endregion

            #region National Dishes Questions

            new Question
            {
                Id = 19,
                QuestionContent = "What is the national dish of the United Kingdom?",
                QuizId = 6,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/6/68/UK_Flag_in_Scotland.jpg"
            },
            
            new Question
            {
                Id = 20,
                QuestionContent = "Which dish is considered the national dish of the United States of America?",
                QuizId = 6,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ea/American_flag.jpg"
            },
            
            new Question
            {
                Id = 21,
                QuestionContent = "What is Japan's national dish?",
                QuizId = 6,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f6/Emperor_of_Japan_Birthday_Akihito_2017.png"
            },
            new Question
            {
                Id = 22,
                QuestionContent = "Which dish is known as the national dish of Hungary?",
                QuizId = 6,
                QuestionImgUrl = "https://upload.wikimedia.org/wikipedia/commons/4/46/Flag_of_Hungary_with_arms_%28state%29.png"
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
            },

            #endregion

            #region Animals: Color Cange Answers

            new Answer
            {
                Id = 49,
                AnswerContent = "Cheetah", IsCorrect = false, QuestionId = 10
            },
            new Answer
            {
                Id = 50,
                AnswerContent = "Chameleon", IsCorrect = true, QuestionId = 10,
            },
            new Answer
            {
                Id = 51,
                AnswerContent = "Gorilla", IsCorrect = false, QuestionId = 10
            },
            new Answer
            {
                Id  = 52,
                AnswerContent = "Sloth", IsCorrect = false, QuestionId = 10
            },

        #endregion
            
            #region Animals: Largest Shark Answers

            new Answer
            {
                Id = 41,
                AnswerContent = "Hammerhead shark", IsCorrect = false, QuestionId = 11
            },
            new Answer
            {
                Id = 42,
                AnswerContent = "Great White shark", IsCorrect = false, QuestionId = 11
            },
            new Answer
            {
                Id = 43,
                AnswerContent = "Bull shark", IsCorrect = false, QuestionId = 11
            },
            new Answer
            {
                Id = 44,
                AnswerContent = "Whale shark", IsCorrect = true, QuestionId = 11
            },

            #endregion

            #region Animals: Largest Land Animal Answers

            new Answer
            {
                Id = 45,
                AnswerContent = "Giraffe", IsCorrect = false, QuestionId = 12
            },
            new Answer
            {
                Id = 46,
                AnswerContent = "African Elephant", IsCorrect = true, QuestionId = 12
            },
            new Answer
            {
                Id = 47,
                AnswerContent = "Polar Bear", IsCorrect = false, QuestionId = 12
            },
            new Answer
            {
                Id = 48,
                AnswerContent = "Hippopotamus", IsCorrect = false, QuestionId = 12
            },

            #endregion
            
            #region Animals: Marsupial Answers

            new Answer
            {
                Id = 37,
                AnswerContent = "Lion", IsCorrect = false, QuestionId = 13
            },
            new Answer
            {
                Id = 38,
                AnswerContent = "Kangaroo", IsCorrect = true, QuestionId = 13
            },
            new Answer
            {
                Id = 39,
                AnswerContent = "Dolphin", IsCorrect = false, QuestionId = 13
            },
            new Answer
            {
                Id = 40,
                AnswerContent = "Penguin", IsCorrect = false, QuestionId = 13
            },

            #endregion

            #region Animals: National Bird of US Answers

            new Answer
            {
                Id = 53,
                AnswerContent = "Bald Eagle", IsCorrect = true, QuestionId = 14
            },
            new Answer
            {
                Id = 54,
                AnswerContent = "American Robin", IsCorrect = false, QuestionId = 14
            },
            new Answer
            {
                Id = 55,
                AnswerContent = "Peregrine Falcon", IsCorrect = false, QuestionId = 14
            },
            new Answer
            {
                Id = 56,
                AnswerContent = "Wild Turkey", IsCorrect = false, QuestionId = 14
            },
            #endregion

            #region Bionicle: Three virtues Asnwers

            new Answer
            {
                Id = 57,
                AnswerContent = "Unity, Duty, Destiny",
                QuestionId = 15,
                IsCorrect = true
            },

            new Answer
            {
                Id = 58,
                AnswerContent = "Power, Courage, Wisdom",
                QuestionId = 15,
                IsCorrect = false
            },

            new Answer
            {
                Id = 59,
                AnswerContent = "Love, Hope, Peace",
                QuestionId = 15,
                IsCorrect = false
            },

            new Answer
            {
                Id = 60,
                AnswerContent = "Imagination, Creativity, Innovation",
                QuestionId = 15,
                IsCorrect = false
            },

            #endregion

            #region Bionicle: Release date Answers
            new Answer
            {
                Id = 61,
                AnswerContent = "2000",
                QuestionId = 16,
                IsCorrect = false
            },

            new Answer
            {
                Id = 62,
                AnswerContent = "2001",
                QuestionId = 16,
                IsCorrect = true
            },

            new Answer
            {
                Id = 63,
                AnswerContent = "2003",
                QuestionId = 16,
                IsCorrect = false
            },

            new Answer
            {
                Id = 64,
                AnswerContent = "2005",
                QuestionId = 16,
                IsCorrect = false
            },
            
            #endregion

            #region Bionicle: Name of the island Answers

            new Answer
            {
                Id = 65,
                AnswerContent = "Metru Nui",
                QuestionId = 17,
                IsCorrect = false
            },

            new Answer
            {
                Id = 66,
                AnswerContent = "Voya Nui",
                QuestionId = 17,
                IsCorrect = false
            },

            new Answer
            {
                Id = 67,
                AnswerContent = "Mata Nui",
                QuestionId = 17,
                IsCorrect = true
            },

            new Answer { 
                    Id = 68,
                    AnswerContent = "Artakha",
                    QuestionId = 17,
                    IsCorrect = false
                },

                #endregion
            
            #region Bionicle: Wild animals Answers

            new Answer
            {
                Id = 69,
                AnswerContent = "Toa",
                QuestionId = 18,
                IsCorrect = false
            },

            new Answer
            { 
                Id = 70,
                AnswerContent = "Matoran",
                QuestionId = 18,
                IsCorrect = false
            },

            new Answer
            {
                Id = 71,
                AnswerContent = "Rahi",
                QuestionId = 18,
                IsCorrect = true
            },

            new Answer
            {
                Id = 72,
                AnswerContent = "Turaga",
                QuestionId = 18,
                IsCorrect = false
            },

            #endregion

            #region National dishes: UK Answers
            new Answer
            {
                Id = 73,
                AnswerContent = "Fish and Chips",
                QuestionId = 19,
                IsCorrect = true
            },

            new Answer
            {
                Id = 74,
                AnswerContent = "Bangers and Mash",
                QuestionId = 19,
                IsCorrect = false
            },

            new Answer
            {
                Id = 75,
                AnswerContent = "Shepherd's Pie",
                QuestionId = 19,
                IsCorrect = false
            },

            new Answer
            {
                Id = 76,
                AnswerContent = "Chicken Tikka Masala",
                QuestionId = 19,
                IsCorrect = false
            },
            
            #endregion

            #region National Dishes: US Answers
            new Answer
            {
                Id = 77,
                AnswerContent = "Hamburger",
                QuestionId = 20,
                IsCorrect = false
            },

            new Answer
            {
                Id = 78,
                AnswerContent = "Hot Dogs",
                QuestionId = 20,
                IsCorrect = false
            },

            new Answer
            {
                Id = 79,
                AnswerContent = "Apple Pie",
                QuestionId = 20,
                IsCorrect = true
            },

            new Answer
            {
                Id = 80,
                AnswerContent = "Fried Chicken",
                QuestionId = 20,
                IsCorrect = false
            },
            
            #endregion

            #region National Dishes: Japan Answers

            new Answer
            {
                Id = 81,
                AnswerContent = "Sushi",
                QuestionId = 21,
                IsCorrect = false
            },

            new Answer
            {
                Id = 82,
                AnswerContent = "Ramen",
                QuestionId = 21,
                IsCorrect = false
            },

            new Answer
            {
                Id = 83,
                AnswerContent = "Tempura",
                QuestionId = 21,
                IsCorrect = false
            },

            new Answer
            {
                Id = 84,
                AnswerContent = "Sushi and Sashimi",
                QuestionId = 21,
                IsCorrect = true
            },

            #endregion

            #region National Dishes: Ungary

            new Answer
            {
                Id = 85,
                AnswerContent = "Goulash",
                QuestionId = 22,
                IsCorrect = true
            },

            new Answer
            {
                Id = 86,
                AnswerContent = "Wiener Schnitzel",
                QuestionId = 22,
                IsCorrect = false
            },

            new Answer
            {
                Id = 87,
                AnswerContent = "Kolbász",
                QuestionId = 22,
                IsCorrect = false
            },

            new Answer
            {
                Id = 88,
                AnswerContent = "Lángos",
                QuestionId = 22,
                IsCorrect = false
            }

            #endregion
        );
    }
}
