using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetWeMe.Api.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 4,
                column: "CategoriesName",
                value: "Shy");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoriesId", "CategoriesName" },
                values: new object[,]
                {
                    { 1, "Select" },
                    { 2, "Glasses" },
                    { 3, "Disable" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoriesId",
                keyValue: 4,
                column: "CategoriesName",
                value: "Disable");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoriesId", "CategoriesName" },
                values: new object[,]
                {
                    { 5, "Shy" },
                    { 6, "Glasses" }
                });
        }
    }
}
