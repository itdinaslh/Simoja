using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class KendaraanAndJenis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NIBPath",
                table: "DetailOlah",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DokumenIzinPath",
                table: "DetailOlah",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NIBPath",
                table: "DetailAngkut",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DokumenIzinPath",
                table: "DetailAngkut",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Telp",
                table: "Clients",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JenisUsahaId",
                table: "Clients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "JenisKendaraan",
                columns: table => new
                {
                    JenisKendaraanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GlobalId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NamaJenis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisKendaraan", x => x.JenisKendaraanId);
                });

            migrationBuilder.CreateTable(
                name: "Kendaraan",
                columns: table => new
                {
                    KendaraanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    NoPolisi = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    NoPintu = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    JenisKendaraanId = table.Column<int>(type: "integer", nullable: false),
                    TglSTNK = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenSTNK = table.Column<string>(type: "text", nullable: false),
                    TglKIR = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenKIR = table.Column<string>(type: "text", nullable: false),
                    FotoKendaraan = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kendaraan", x => x.KendaraanId);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                        column: x => x.JenisKendaraanId,
                        principalTable: "JenisKendaraan",
                        principalColumn: "JenisKendaraanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JenisKendaraan_GlobalId",
                table: "JenisKendaraan",
                column: "GlobalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_ClientId",
                table: "Kendaraan",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_JenisKendaraanId",
                table: "Kendaraan",
                column: "JenisKendaraanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kendaraan");

            migrationBuilder.DropTable(
                name: "JenisKendaraan");

            migrationBuilder.AlterColumn<string>(
                name: "NIBPath",
                table: "DetailOlah",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DokumenIzinPath",
                table: "DetailOlah",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NIBPath",
                table: "DetailAngkut",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DokumenIzinPath",
                table: "DetailAngkut",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telp",
                table: "Clients",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "JenisUsahaId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
