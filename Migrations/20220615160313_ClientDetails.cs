using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class ClientDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DokumenIzinPath",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DokumenNIBPath",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "NIB",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "NoIzinUsaha",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TglAkhirIzin",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TglTerbitIzin",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientGuid",
                table: "Clients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DetailAngkut",
                columns: table => new
                {
                    DetailAngkutId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    JmlAngkutan = table.Column<int>(type: "integer", nullable: false),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: false),
                    NIB = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NIBPath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailAngkut", x => x.DetailAngkutId);
                    table.ForeignKey(
                        name: "FK_DetailAngkut_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailKawasan",
                columns: table => new
                {
                    DetailKawasanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    JenisKegiatanID = table.Column<int>(type: "integer", nullable: false),
                    StatusKelolaID = table.Column<int>(type: "integer", nullable: false),
                    TimbulanAvg = table.Column<int>(type: "integer", nullable: true),
                    IsDipilah = table.Column<bool>(type: "boolean", nullable: true),
                    JumlahPilah = table.Column<double>(type: "double precision", nullable: true),
                    JenisPilah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsPembatasan = table.Column<bool>(type: "boolean", nullable: true),
                    Upaya = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PunyaTps = table.Column<bool>(type: "boolean", nullable: true),
                    TpsTerpilah = table.Column<bool>(type: "boolean", nullable: true),
                    DimensiTps = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    IsOlah = table.Column<bool>(type: "boolean", nullable: true),
                    JenisOlah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LokasiOlah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OlahAvg = table.Column<double>(type: "double precision", nullable: true),
                    PihakAngkutID = table.Column<int>(type: "integer", nullable: true),
                    NamaPengolah = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LokasiOlahLuar = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WadahPath = table.Column<string>(type: "text", nullable: true),
                    TpsPath = table.Column<string>(type: "text", nullable: true),
                    PengolahanPath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailKawasan", x => x.DetailKawasanId);
                    table.ForeignKey(
                        name: "FK_DetailKawasan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailKawasan_JenisKegiatan_JenisKegiatanID",
                        column: x => x.JenisKegiatanID,
                        principalTable: "JenisKegiatan",
                        principalColumn: "JenisKegiatanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailKawasan_PihakAngkut_PihakAngkutID",
                        column: x => x.PihakAngkutID,
                        principalTable: "PihakAngkut",
                        principalColumn: "PihakAngkutID");
                });

            migrationBuilder.CreateTable(
                name: "DetailOlah",
                columns: table => new
                {
                    DetailOlahId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: false),
                    NIB = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NIBPath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOlah", x => x.DetailOlahId);
                    table.ForeignKey(
                        name: "FK_DetailOlah_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailAngkut_ClientId",
                table: "DetailAngkut",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailKawasan_ClientId",
                table: "DetailKawasan",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailKawasan_JenisKegiatanID",
                table: "DetailKawasan",
                column: "JenisKegiatanID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailKawasan_PihakAngkutID",
                table: "DetailKawasan",
                column: "PihakAngkutID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOlah_ClientId",
                table: "DetailOlah",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailAngkut");

            migrationBuilder.DropTable(
                name: "DetailKawasan");

            migrationBuilder.DropTable(
                name: "DetailOlah");

            migrationBuilder.DropColumn(
                name: "ClientGuid",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "DokumenIzinPath",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DokumenNIBPath",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIB",
                table: "Clients",
                type: "character varying(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoIzinUsaha",
                table: "Clients",
                type: "character varying(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "TglAkhirIzin",
                table: "Clients",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "TglTerbitIzin",
                table: "Clients",
                type: "date",
                nullable: true);
        }
    }
}
