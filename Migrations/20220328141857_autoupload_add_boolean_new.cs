using Microsoft.EntityFrameworkCore.Migrations;

namespace etf.myemitent.ru.Migrations
{
    public partial class autoupload_add_boolean_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AutoUpload",
                table: "Etfs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoUpload",
                table: "Etfs");
        }
    }
}
