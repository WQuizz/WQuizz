using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 62f, 82f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 92f, 91f });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Popularity", "Rating" },
                values: new object[] { 97f, 77f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserProfiles");

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
    }
}
