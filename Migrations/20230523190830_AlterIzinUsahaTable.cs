using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterIzinUsahaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzinUsahas_JenisIzinLingkungans_JenisIzinLingkunganID",
                table: "IzinUsahas");

            migrationBuilder.DropForeignKey(
                name: "FK_IzinUsahas_JenisKegiatan_JenisKegiatanID",
                table: "IzinUsahas");

            migrationBuilder.DropForeignKey(
                name: "FK_IzinUsahas_LokasiIzin_LokasiIzinID",
                table: "IzinUsahas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IzinUsahas",
                table: "IzinUsahas");

            migrationBuilder.RenameTable(
                name: "IzinUsahas",
                newName: "Kawasan");

            migrationBuilder.RenameIndex(
                name: "IX_IzinUsahas_LokasiIzinID",
                table: "Kawasan",
                newName: "IX_Kawasan_LokasiIzinID");

            migrationBuilder.RenameIndex(
                name: "IX_IzinUsahas_JenisKegiatanID",
                table: "Kawasan",
                newName: "IX_Kawasan_JenisKegiatanID");

            migrationBuilder.RenameIndex(
                name: "IX_IzinUsahas_JenisIzinLingkunganID",
                table: "Kawasan",
                newName: "IX_Kawasan_JenisIzinLingkunganID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kawasan",
                table: "Kawasan",
                column: "KawasanID");

            migrationBuilder.CreateIndex(
                name: "IX_Kawasan_ClientID",
                table: "Kawasan",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kawasan_Clients_ClientID",
                table: "Kawasan",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kawasan_JenisIzinLingkungans_JenisIzinLingkunganID",
                table: "Kawasan",
                column: "JenisIzinLingkunganID",
                principalTable: "JenisIzinLingkungans",
                principalColumn: "JenisIzinLingkunganID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kawasan_JenisKegiatan_JenisKegiatanID",
                table: "Kawasan",
                column: "JenisKegiatanID",
                principalTable: "JenisKegiatan",
                principalColumn: "JenisKegiatanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kawasan_LokasiIzin_LokasiIzinID",
                table: "Kawasan",
                column: "LokasiIzinID",
                principalTable: "LokasiIzin",
                principalColumn: "LokasiIzinID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kawasan_Clients_ClientID",
                table: "Kawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_Kawasan_JenisIzinLingkungans_JenisIzinLingkunganID",
                table: "Kawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_Kawasan_JenisKegiatan_JenisKegiatanID",
                table: "Kawasan");

            migrationBuilder.DropForeignKey(
                name: "FK_Kawasan_LokasiIzin_LokasiIzinID",
                table: "Kawasan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kawasan",
                table: "Kawasan");

            migrationBuilder.DropIndex(
                name: "IX_Kawasan_ClientID",
                table: "Kawasan");

            migrationBuilder.RenameTable(
                name: "Kawasan",
                newName: "IzinUsahas");

            migrationBuilder.RenameIndex(
                name: "IX_Kawasan_LokasiIzinID",
                table: "IzinUsahas",
                newName: "IX_IzinUsahas_LokasiIzinID");

            migrationBuilder.RenameIndex(
                name: "IX_Kawasan_JenisKegiatanID",
                table: "IzinUsahas",
                newName: "IX_IzinUsahas_JenisKegiatanID");

            migrationBuilder.RenameIndex(
                name: "IX_Kawasan_JenisIzinLingkunganID",
                table: "IzinUsahas",
                newName: "IX_IzinUsahas_JenisIzinLingkunganID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IzinUsahas",
                table: "IzinUsahas",
                column: "KawasanID");

            migrationBuilder.AddForeignKey(
                name: "FK_IzinUsahas_JenisIzinLingkungans_JenisIzinLingkunganID",
                table: "IzinUsahas",
                column: "JenisIzinLingkunganID",
                principalTable: "JenisIzinLingkungans",
                principalColumn: "JenisIzinLingkunganID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IzinUsahas_JenisKegiatan_JenisKegiatanID",
                table: "IzinUsahas",
                column: "JenisKegiatanID",
                principalTable: "JenisKegiatan",
                principalColumn: "JenisKegiatanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IzinUsahas_LokasiIzin_LokasiIzinID",
                table: "IzinUsahas",
                column: "LokasiIzinID",
                principalTable: "LokasiIzin",
                principalColumn: "LokasiIzinID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
