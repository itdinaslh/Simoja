using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class RenameOlahAndKawasanIzinId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailOlahId",
                table: "IzinOlah",
                newName: "IzinOlahId");

            migrationBuilder.RenameColumn(
                name: "DetailKawasanId",
                table: "IzinKawasan",
                newName: "IzinKawasanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IzinOlahId",
                table: "IzinOlah",
                newName: "DetailOlahId");

            migrationBuilder.RenameColumn(
                name: "IzinKawasanId",
                table: "IzinKawasan",
                newName: "DetailKawasanId");
        }
    }
}
