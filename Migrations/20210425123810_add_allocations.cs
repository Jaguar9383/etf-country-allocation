using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace etf.myemitent.ru.Migrations
{
    public partial class add_allocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Etfs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Etfs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EtfCountryAllocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EtfId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Allocation = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtfCountryAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtfCountryAllocations_Etfs_EtfId",
                        column: x => x.EtfId,
                        principalTable: "Etfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etfs_CountryId",
                table: "Etfs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EtfCountryAllocations_EtfId",
                table: "EtfCountryAllocations",
                column: "EtfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etfs_Countries_CountryId",
                table: "Etfs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etfs_Countries_CountryId",
                table: "Etfs");

            migrationBuilder.DropTable(
                name: "EtfCountryAllocations");

            migrationBuilder.DropIndex(
                name: "IX_Etfs_CountryId",
                table: "Etfs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Etfs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Etfs");
        }
    }
}
