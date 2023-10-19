using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Popularity", "Rating" },
                values: new object[] { 2, 100f, 100f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Popularity", "Rating" },
                values: new object[] { 1, 90f, 60f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Popularity", "Rating" },
                values: new object[] { 5, 74f, 83f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Popularity", "Rating" },
                values: new object[] { 5, 58f, 90f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Quizzes");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 0f, 0f });
        }
    }
}
