using Microsoft.EntityFrameworkCore.Migrations;

namespace etf.myemitent.ru.Migrations
{
    public partial class autoupload_remove_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoUpload",
                table: "Etfs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutoUpload",
                table: "Etfs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
