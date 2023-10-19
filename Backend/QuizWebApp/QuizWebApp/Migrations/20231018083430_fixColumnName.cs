using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizWebApp.Migrations
{
    /// <inheritdoc />
    public partial class fixColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Quizzes",
                newName: "CategoryType");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 78f, 71f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 54f, 50f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 82f, 91f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "Quizzes",
                newName: "Category");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 90f, 60f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 74f, 83f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 58f, 90f });
        }
    }
}
