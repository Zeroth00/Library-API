using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiProje.Migrations
{
    public partial class InitFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holder",
                table: "BooksDb");

            migrationBuilder.AddColumn<long>(
                name: "HolderId",
                table: "BooksDb",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolderId",
                table: "BooksDb");

            migrationBuilder.AddColumn<string>(
                name: "Holder",
                table: "BooksDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
