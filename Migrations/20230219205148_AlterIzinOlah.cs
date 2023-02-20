using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterIzinOlah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DokumenIzinPath",
                table: "IzinOlah",
                newName: "DokumenIzin");

            migrationBuilder.AddColumn<int>(
                name: "JumlahTeknologi",
                table: "IzinOlah",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LokasiIzinID",
                table: "IzinOlah",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IzinOlah_LokasiIzinID",
                table: "IzinOlah",
                column: "LokasiIzinID");

            migrationBuilder.AddForeignKey(
                name: "FK_IzinOlah_LokasiIzin_LokasiIzinID",
                table: "IzinOlah",
                column: "LokasiIzinID",
                principalTable: "LokasiIzin",
                principalColumn: "LokasiIzinID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzinOlah_LokasiIzin_LokasiIzinID",
                table: "IzinOlah");

            migrationBuilder.DropIndex(
                name: "IX_IzinOlah_LokasiIzinID",
                table: "IzinOlah");

            migrationBuilder.DropColumn(
                name: "JumlahTeknologi",
                table: "IzinOlah");

            migrationBuilder.DropColumn(
                name: "LokasiIzinID",
                table: "IzinOlah");

            migrationBuilder.RenameColumn(
                name: "DokumenIzin",
                table: "IzinOlah",
                newName: "DokumenIzinPath");
        }
    }
}
