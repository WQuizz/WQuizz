using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ExtendSeedSprint4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionContent", "QuestionImgUrl", "QuizId", "TimeLimit" },
                values: new object[,]
                {
                    { 15, "What are the three virtues of the Bionicle Universe?", "https://biosector01.com/w/images/bs01/b/b6/BIONICLE_Logo.png", 4, null },
                    { 16, "When was Bionicle first released?", "https://biosector01.com/w/images/bs01/0/0e/Toa_Mata_Sets.jpg", 4, null },
                    { 17, "What's the name of the island Bionicle first took place in?", "https://biosector01.com/w/images/bs01/a/a2/CGI_Mata_Nui_%28Island%29.jpg", 4, null },
                    { 18, "What are wild animals in the Bionicle universe called?", "https://biosector01.com/w/images/bs01/b/b2/Promo_Art_Rahi.png", 4, null }
                });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 61f, 99f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 54f, 73f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 85f, 50f });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CategoryType", "Difficulty", "IsApproved", "Popularity", "QuizName", "Rating", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 5, 0, 1, true, 90f, "All about Animals!", 87f, "https://static.wikia.nocookie.net/mythology/images/f/f7/Animal_Collage.jpg/revision/latest/scale-to-width-down/600?cb=20210219055843" },
                    { 6, 3, 1, true, 75f, "National Dishes Around the World", 97f, "https://www.cactuslanguage.com/wp-content/uploads/2022/09/table-of-food.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerContent", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 57, "Unity, Duty, Destiny", true, 15 },
                    { 58, "Power, Courage, Wisdom", false, 15 },
                    { 59, "Love, Hope, Peace", false, 15 },
                    { 60, "Imagination, Creativity, Innovation", false, 15 },
                    { 61, "2000", false, 16 },
                    { 62, "2001", true, 16 },
                    { 63, "2003", false, 16 },
                    { 64, "2005", false, 16 },
                    { 65, "Metru Nui", false, 17 },
                    { 66, "Voya Nui", false, 17 },
                    { 67, "Mata Nui", true, 17 },
                    { 68, "Artakha", false, 17 },
                    { 69, "Toa", false, 18 },
                    { 70, "Matoran", false, 18 },
                    { 71, "Rahi", true, 18 },
                    { 72, "Turaga", false, 18 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionContent", "QuestionImgUrl", "QuizId", "TimeLimit" },
                values: new object[,]
                {
                    { 10, "Which of these animals is known for its ability to change color to camouflage itself?", "https://static.spokanecity.org/photos/2019/09/30/leaf-colors/16x10/Full/leaf-colors.jpg", 5, null },
                    { 11, "What is the largest species of shark?", "https://upload.wikimedia.org/wikipedia/commons/5/59/Caribbean_reef_shark.jpg", 5, null },
                    { 12, "What is the largest land animal on Earth?", "https://i.ytimg.com/vi/KhfCgkJmg8M/maxresdefault.jpg", 5, null },
                    { 13, "Which of the following animals is a marsupial?", "https://cdn.britannica.com/07/154807-050-3226C065/species-Wombat-wombats-wombat-population-Tasmania-Australia.jpg", 5, null },
                    { 14, "What is the national bird of the United States?", "https://www.usnews.com/object/image/0000016f-8c62-d408-a9ef-9ffe94a60000/200115bcusaprofile-editorial.usa.profile.jpg?update-time=1578608368142&size=superhero-medium", 5, null },
                    { 19, "What is the national dish of the United Kingdom?", "https://upload.wikimedia.org/wikipedia/commons/6/68/UK_Flag_in_Scotland.jpg", 6, null },
                    { 20, "Which dish is considered the national dish of the United States of America?", "https://upload.wikimedia.org/wikipedia/commons/e/ea/American_flag.jpg", 6, null },
                    { 21, "What is Japan's national dish?", "https://upload.wikimedia.org/wikipedia/commons/f/f6/Emperor_of_Japan_Birthday_Akihito_2017.png", 6, null },
                    { 22, "Which dish is known as the national dish of Hungary?", "https://upload.wikimedia.org/wikipedia/commons/4/46/Flag_of_Hungary_with_arms_%28state%29.png", 6, null }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerContent", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 37, "Lion", false, 13 },
                    { 38, "Kangaroo", true, 13 },
                    { 39, "Dolphin", false, 13 },
                    { 40, "Penguin", false, 13 },
                    { 41, "Hammerhead shark", false, 11 },
                    { 42, "Great White shark", false, 11 },
                    { 43, "Bull shark", false, 11 },
                    { 44, "Whale shark", true, 11 },
                    { 45, "Giraffe", false, 12 },
                    { 46, "African Elephant", true, 12 },
                    { 47, "Polar Bear", false, 12 },
                    { 48, "Hippopotamus", false, 12 },
                    { 49, "Cheetah", false, 10 },
                    { 50, "Chameleon", true, 10 },
                    { 51, "Gorilla", false, 10 },
                    { 52, "Sloth", false, 10 },
                    { 53, "Bald Eagle", true, 14 },
                    { 54, "American Robin", false, 14 },
                    { 55, "Peregrine Falcon", false, 14 },
                    { 56, "Wild Turkey", false, 14 },
                    { 73, "Fish and Chips", true, 19 },
                    { 74, "Bangers and Mash", false, 19 },
                    { 75, "Shepherd's Pie", false, 19 },
                    { 76, "Chicken Tikka Masala", false, 19 },
                    { 77, "Hamburger", false, 20 },
                    { 78, "Hot Dogs", false, 20 },
                    { 79, "Apple Pie", true, 20 },
                    { 80, "Fried Chicken", false, 20 },
                    { 81, "Sushi", false, 21 },
                    { 82, "Ramen", false, 21 },
                    { 83, "Tempura", false, 21 },
                    { 84, "Sushi and Sashimi", true, 21 },
                    { 85, "Goulash", true, 22 },
                    { 86, "Wiener Schnitzel", false, 22 },
                    { 87, "Kolbász", false, 22 },
                    { 88, "Lángos", false, 22 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 87f, 66f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 62f, 64f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 59f, 95f });
        }
    }
}
