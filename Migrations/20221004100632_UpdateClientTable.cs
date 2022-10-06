using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class UpdateClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIB",
                table: "DetailAngkut");

            migrationBuilder.AddColumn<string>(
                name: "DokumenPath",
                table: "LokasiAngkut",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIB",
                table: "Clients",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DokumenPath",
                table: "LokasiAngkut");

            migrationBuilder.DropColumn(
                name: "NIB",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "NIB",
                table: "DetailAngkut",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
