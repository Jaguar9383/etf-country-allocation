using Microsoft.EntityFrameworkCore.Migrations;

namespace etf.myemitent.ru.Migrations
{
    public partial class rename_etf_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Etf",
                table: "Etf");

            migrationBuilder.RenameTable(
                name: "Etf",
                newName: "Etfs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etfs",
                table: "Etfs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Etfs",
                table: "Etfs");

            migrationBuilder.RenameTable(
                name: "Etfs",
                newName: "Etf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etf",
                table: "Etf",
                column: "Id");
        }
    }
}
