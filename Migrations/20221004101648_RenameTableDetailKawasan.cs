using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class RenameTableDetailKawasan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailKawasan_Clients_ClientId",
                table: "DetailKawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailKawasan_JenisKegiatan_JenisKegiatanID",
                table: "DetailKawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailKawasan_PihakAngkut_PihakAngkutID",
                table: "DetailKawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailKawasan_StatusKelola_StatusKelolaID",
                table: "DetailKawasan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailKawasan",
                table: "DetailKawasan");

            migrationBuilder.RenameTable(
                name: "DetailKawasan",
                newName: "IzinKawasan");

            migrationBuilder.RenameIndex(
                name: "IX_DetailKawasan_StatusKelolaID",
                table: "IzinKawasan",
                newName: "IX_IzinKawasan_StatusKelolaID");

            migrationBuilder.RenameIndex(
                name: "IX_DetailKawasan_PihakAngkutID",
                table: "IzinKawasan",
                newName: "IX_IzinKawasan_PihakAngkutID");

            migrationBuilder.RenameIndex(
                name: "IX_DetailKawasan_JenisKegiatanID",
                table: "IzinKawasan",
                newName: "IX_IzinKawasan_JenisKegiatanID");

            migrationBuilder.RenameIndex(
                name: "IX_DetailKawasan_ClientId",
                table: "IzinKawasan",
                newName: "IX_IzinKawasan_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IzinKawasan",
                table: "IzinKawasan",
                column: "DetailKawasanId");

            migrationBuilder.AddForeignKey(
                name: "FK_IzinKawasan_Clients_ClientId",
                table: "IzinKawasan",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IzinKawasan_JenisKegiatan_JenisKegiatanID",
                table: "IzinKawasan",
                column: "JenisKegiatanID",
                principalTable: "JenisKegiatan",
                principalColumn: "JenisKegiatanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IzinKawasan_PihakAngkut_PihakAngkutID",
                table: "IzinKawasan",
                column: "PihakAngkutID",
                principalTable: "PihakAngkut",
                principalColumn: "PihakAngkutID");

            migrationBuilder.AddForeignKey(
                name: "FK_IzinKawasan_StatusKelola_StatusKelolaID",
                table: "IzinKawasan",
                column: "StatusKelolaID",
                principalTable: "StatusKelola",
                principalColumn: "StatusKelolaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzinKawasan_Clients_ClientId",
                table: "IzinKawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_IzinKawasan_JenisKegiatan_JenisKegiatanID",
                table: "IzinKawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_IzinKawasan_PihakAngkut_PihakAngkutID",
                table: "IzinKawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_IzinKawasan_StatusKelola_StatusKelolaID",
                table: "IzinKawasan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IzinKawasan",
                table: "IzinKawasan");

            migrationBuilder.RenameTable(
                name: "IzinKawasan",
                newName: "DetailKawasan");

            migrationBuilder.RenameIndex(
                name: "IX_IzinKawasan_StatusKelolaID",
                table: "DetailKawasan",
                newName: "IX_DetailKawasan_StatusKelolaID");

            migrationBuilder.RenameIndex(
                name: "IX_IzinKawasan_PihakAngkutID",
                table: "DetailKawasan",
                newName: "IX_DetailKawasan_PihakAngkutID");

            migrationBuilder.RenameIndex(
                name: "IX_IzinKawasan_JenisKegiatanID",
                table: "DetailKawasan",
                newName: "IX_DetailKawasan_JenisKegiatanID");

            migrationBuilder.RenameIndex(
                name: "IX_IzinKawasan_ClientId",
                table: "DetailKawasan",
                newName: "IX_DetailKawasan_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailKawasan",
                table: "DetailKawasan",
                column: "DetailKawasanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailKawasan_Clients_ClientId",
                table: "DetailKawasan",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailKawasan_JenisKegiatan_JenisKegiatanID",
                table: "DetailKawasan",
                column: "JenisKegiatanID",
                principalTable: "JenisKegiatan",
                principalColumn: "JenisKegiatanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailKawasan_PihakAngkut_PihakAngkutID",
                table: "DetailKawasan",
                column: "PihakAngkutID",
                principalTable: "PihakAngkut",
                principalColumn: "PihakAngkutID");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailKawasan_StatusKelola_StatusKelolaID",
                table: "DetailKawasan",
                column: "StatusKelolaID",
                principalTable: "StatusKelola",
                principalColumn: "StatusKelolaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
