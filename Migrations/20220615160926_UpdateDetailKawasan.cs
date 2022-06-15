using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class UpdateDetailKawasan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DetailKawasan_StatusKelolaID",
                table: "DetailKawasan",
                column: "StatusKelolaID");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailKawasan_StatusKelola_StatusKelolaID",
                table: "DetailKawasan",
                column: "StatusKelolaID",
                principalTable: "StatusKelola",
                principalColumn: "StatusKelolaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailKawasan_StatusKelola_StatusKelolaID",
                table: "DetailKawasan");

            migrationBuilder.DropIndex(
                name: "IX_DetailKawasan_StatusKelolaID",
                table: "DetailKawasan");
        }
    }
}
