using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetWeMe.Api.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Categories_CategoriesId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Categories_CategoriesId",
                table: "Users",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Categories_CategoriesId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Categories_CategoriesId",
                table: "Users",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId");
        }
    }
}
