using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterIzinKawasans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinKawasan");

            migrationBuilder.DropTable(
                name: "Kawasan");

            migrationBuilder.CreateTable(
                name: "IzinKegiatan",
                columns: table => new
                {
                    IzinKegiatanID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaKawasan = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LokasiIzinID = table.Column<int>(type: "integer", nullable: false),
                    JenisKegiatanID = table.Column<int>(type: "integer", nullable: false),
                    JenisIzinLingkunganID = table.Column<int>(type: "integer", nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: true),
                    DokumenIzin = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PihakAngkutID = table.Column<int>(type: "integer", nullable: true),
                    StatusKelolaID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinKegiatan", x => x.IzinKegiatanID);
                    table.ForeignKey(
                        name: "FK_IzinKegiatan_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinKegiatan_JenisIzinLingkungans_JenisIzinLingkunganID",
                        column: x => x.JenisIzinLingkunganID,
                        principalTable: "JenisIzinLingkungans",
                        principalColumn: "JenisIzinLingkunganID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinKegiatan_JenisKegiatan_JenisKegiatanID",
                        column: x => x.JenisKegiatanID,
                        principalTable: "JenisKegiatan",
                        principalColumn: "JenisKegiatanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinKegiatan_LokasiIzin_LokasiIzinID",
                        column: x => x.LokasiIzinID,
                        principalTable: "LokasiIzin",
                        principalColumn: "LokasiIzinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinKegiatan_PihakAngkut_PihakAngkutID",
                        column: x => x.PihakAngkutID,
                        principalTable: "PihakAngkut",
                        principalColumn: "PihakAngkutID");
                    table.ForeignKey(
                        name: "FK_IzinKegiatan_StatusKelola_StatusKelolaID",
                        column: x => x.StatusKelolaID,
                        principalTable: "StatusKelola",
                        principalColumn: "StatusKelolaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzinKegiatan_ClientID",
                table: "IzinKegiatan",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKegiatan_JenisIzinLingkunganID",
                table: "IzinKegiatan",
                column: "JenisIzinLingkunganID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKegiatan_JenisKegiatanID",
                table: "IzinKegiatan",
                column: "JenisKegiatanID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKegiatan_LokasiIzinID",
                table: "IzinKegiatan",
                column: "LokasiIzinID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKegiatan_PihakAngkutID",
                table: "IzinKegiatan",
                column: "PihakAngkutID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKegiatan_StatusKelolaID",
                table: "IzinKegiatan",
                column: "StatusKelolaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinKegiatan");

            migrationBuilder.CreateTable(
                name: "IzinKawasan",
                columns: table => new
                {
                    IzinKawasanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JenisKegiatanID = table.Column<int>(type: "integer", nullable: false),
                    PihakAngkutID = table.Column<int>(type: "integer", nullable: true),
                    StatusKelolaID = table.Column<int>(type: "integer", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DimensiTps = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    IsDipilah = table.Column<bool>(type: "boolean", nullable: true),
                    IsOlah = table.Column<bool>(type: "boolean", nullable: true),
                    IsPembatasan = table.Column<bool>(type: "boolean", nullable: true),
                    JenisOlah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JenisPilah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JumlahPilah = table.Column<double>(type: "double precision", nullable: true),
                    LokasiOlah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LokasiOlahLuar = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NamaPengolah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OlahAvg = table.Column<double>(type: "double precision", nullable: true),
                    PengolahanPath = table.Column<string>(type: "text", nullable: true),
                    PunyaTps = table.Column<bool>(type: "boolean", nullable: true),
                    TimbulanAvg = table.Column<int>(type: "integer", nullable: true),
                    TpsPath = table.Column<string>(type: "text", nullable: true),
                    TpsTerpilah = table.Column<bool>(type: "boolean", nullable: true),
                    Upaya = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WadahPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinKawasan", x => x.IzinKawasanID);
                    table.ForeignKey(
                        name: "FK_IzinKawasan_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinKawasan_JenisKegiatan_JenisKegiatanID",
                        column: x => x.JenisKegiatanID,
                        principalTable: "JenisKegiatan",
                        principalColumn: "JenisKegiatanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinKawasan_PihakAngkut_PihakAngkutID",
                        column: x => x.PihakAngkutID,
                        principalTable: "PihakAngkut",
                        principalColumn: "PihakAngkutID");
                    table.ForeignKey(
                        name: "FK_IzinKawasan_StatusKelola_StatusKelolaID",
                        column: x => x.StatusKelolaID,
                        principalTable: "StatusKelola",
                        principalColumn: "StatusKelolaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kawasan",
                columns: table => new
                {
                    KawasanID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    JenisIzinLingkunganID = table.Column<int>(type: "integer", nullable: false),
                    JenisKegiatanID = table.Column<int>(type: "integer", nullable: false),
                    LokasiIzinID = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DokumenIzin = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    NamaKawasan = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kawasan", x => x.KawasanID);
                    table.ForeignKey(
                        name: "FK_Kawasan_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kawasan_JenisIzinLingkungans_JenisIzinLingkunganID",
                        column: x => x.JenisIzinLingkunganID,
                        principalTable: "JenisIzinLingkungans",
                        principalColumn: "JenisIzinLingkunganID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kawasan_JenisKegiatan_JenisKegiatanID",
                        column: x => x.JenisKegiatanID,
                        principalTable: "JenisKegiatan",
                        principalColumn: "JenisKegiatanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kawasan_LokasiIzin_LokasiIzinID",
                        column: x => x.LokasiIzinID,
                        principalTable: "LokasiIzin",
                        principalColumn: "LokasiIzinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzinKawasan_ClientID",
                table: "IzinKawasan",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKawasan_JenisKegiatanID",
                table: "IzinKawasan",
                column: "JenisKegiatanID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKawasan_PihakAngkutID",
                table: "IzinKawasan",
                column: "PihakAngkutID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinKawasan_StatusKelolaID",
                table: "IzinKawasan",
                column: "StatusKelolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kawasan_ClientID",
                table: "Kawasan",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Kawasan_JenisIzinLingkunganID",
                table: "Kawasan",
                column: "JenisIzinLingkunganID");

            migrationBuilder.CreateIndex(
                name: "IX_Kawasan_JenisKegiatanID",
                table: "Kawasan",
                column: "JenisKegiatanID");

            migrationBuilder.CreateIndex(
                name: "IX_Kawasan_LokasiIzinID",
                table: "Kawasan",
                column: "LokasiIzinID");
        }
    }
}
