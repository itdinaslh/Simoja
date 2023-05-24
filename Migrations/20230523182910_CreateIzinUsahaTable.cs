using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateIzinUsahaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IzinUsahas",
                columns: table => new
                {
                    KawasanID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaKawasan = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LokasiIzinID = table.Column<int>(type: "integer", nullable: false),
                    JenisKegiatanID = table.Column<int>(type: "integer", nullable: false),
                    JenisIzinLingkunganID = table.Column<int>(type: "integer", nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: true),
                    DokumenIzin = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinUsahas", x => x.KawasanID);
                    table.ForeignKey(
                        name: "FK_IzinUsahas_JenisIzinLingkungans_JenisIzinLingkunganID",
                        column: x => x.JenisIzinLingkunganID,
                        principalTable: "JenisIzinLingkungans",
                        principalColumn: "JenisIzinLingkunganID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinUsahas_JenisKegiatan_JenisKegiatanID",
                        column: x => x.JenisKegiatanID,
                        principalTable: "JenisKegiatan",
                        principalColumn: "JenisKegiatanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinUsahas_LokasiIzin_LokasiIzinID",
                        column: x => x.LokasiIzinID,
                        principalTable: "LokasiIzin",
                        principalColumn: "LokasiIzinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzinUsahas_JenisIzinLingkunganID",
                table: "IzinUsahas",
                column: "JenisIzinLingkunganID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinUsahas_JenisKegiatanID",
                table: "IzinUsahas",
                column: "JenisKegiatanID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinUsahas_LokasiIzinID",
                table: "IzinUsahas",
                column: "LokasiIzinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinUsahas");
        }
    }
}
