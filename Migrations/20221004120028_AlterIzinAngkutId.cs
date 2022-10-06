using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterIzinAngkutId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailAngkutId",
                table: "IzinAngkut",
                newName: "IzinAngkutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IzinAngkutId",
                table: "IzinAngkut",
                newName: "DetailAngkutId");
        }
    }
}
