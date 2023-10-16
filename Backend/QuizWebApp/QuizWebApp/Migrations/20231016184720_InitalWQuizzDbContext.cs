using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitalWQuizzDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<float>(type: "real", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeLimit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Difficulty", "IsApproved", "Popularity", "QuizName", "Rating", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 1, 0, true, 0f, "Capital Cities around the World", 0f, "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Prague_%286365119737%29.jpg/1920px-Prague_%286365119737%29.jpg" },
                    { 2, 1, true, 0f, "Chemical Symbols", 0f, "https://i.pinimg.com/originals/de/54/d3/de54d3e8700cbb87d534844531ae5b71.png" },
                    { 3, 2, true, 0f, "Retro Gaming", 0f, "https://as2.ftcdn.net/v2/jpg/05/59/01/05/1000_F_559010542_cXULDCcdcVwWCcf0DcE7V3QhCQO44Ryh.jpg" },
                    { 4, 2, true, 0f, "Bionicle Lore", 0f, "https://biosector01.com/w/images/bs01/0/0e/Toa_Mata_Sets.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionContent", "QuestionImgUrl", "QuizId", "TimeLimit" },
                values: new object[,]
                {
                    { 1, "What is the capital of France?", "https://static.vecteezy.com/system/resources/previews/008/726/860/original/map-of-france-outline-map-illustration-free-vector.jpg", 1, null },
                    { 2, "What is the capital of the USA?", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Map_of_USA_with_state_names.svg/langhu-800px-Map_of_USA_with_state_names.svg.png", 1, null },
                    { 3, "What is the capital of Japan?", "https://cdn.pixabay.com/photo/2013/05/22/18/00/japan-112722_1280.jpg", 1, null },
                    { 4, "What is the capital of Denmark?", "https://static.vecteezy.com/system/resources/previews/019/476/194/original/denmark-map-in-europe-zoom-version-icons-showing-denmark-location-and-flags-vector.jpg", 1, null },
                    { 5, "What is the chemical symbol of Uranium", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/HEUraniumC.jpg/1200px-HEUraniumC.jpg", 2, null },
                    { 6, "What is the chemical symbol of Helium?", "https://static.wikia.nocookie.net/fortnite/images/d/da/Balloons_%28Old%29_-_Item_-_Fortnite.png/revision/latest?cb=20200717131102", 2, null },
                    { 7, "What is the chemical symbol of Magnesium?", "https://upload.wikimedia.org/wikipedia/commons/5/5c/CSIRO_ScienceImage_2893_Crystalised_magnesium.jpg", 2, null },
                    { 8, "What is the chemical symbol of Gold?", "https://upload.wikimedia.org/wikipedia/commons/6/69/Gold_nugget_%28Australia%29_4_%2816848647509%29.jpg", 2, null },
                    { 9, "What is the chemical symbol of Silver?", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Silver_crystal.jpg/1200px-Silver_crystal.jpg", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerContent", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Berlin", false, 1 },
                    { 2, "Orleans", false, 1 },
                    { 3, "Paris", true, 1 },
                    { 4, "Brussels", false, 1 },
                    { 5, "Houston", false, 2 },
                    { 6, "New York", false, 2 },
                    { 7, "Dallas", false, 2 },
                    { 8, "Washington, D.C", true, 2 },
                    { 9, "Kyoto", false, 3 },
                    { 10, "Tokyo", true, 3 },
                    { 11, "Okinawa", true, 3 },
                    { 12, "Yokohama", false, 3 },
                    { 13, "Copenhagen", true, 4 },
                    { 14, "Arhus", false, 4 },
                    { 15, "Aalborg", false, 4 },
                    { 16, "Frederiksberg", false, 4 },
                    { 17, "U", true, 5 },
                    { 18, "Ur", false, 5 },
                    { 19, "Ua", false, 5 },
                    { 20, "An", false, 5 },
                    { 21, "H", false, 6 },
                    { 22, "He", true, 6 },
                    { 23, "Hl", false, 6 },
                    { 24, "Hx", false, 6 },
                    { 25, "M", false, 7 },
                    { 26, "Ma", false, 7 },
                    { 27, "Mg", true, 7 },
                    { 28, "Na", false, 7 },
                    { 29, "G", false, 8 },
                    { 30, "Go", false, 8 },
                    { 31, "Au", true, 8 },
                    { 32, "Ar", false, 8 },
                    { 33, "S", false, 9 },
                    { 34, "Si", false, 9 },
                    { 35, "Ar", false, 9 },
                    { 36, "Ag", true, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
