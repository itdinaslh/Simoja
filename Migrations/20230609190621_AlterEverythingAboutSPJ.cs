using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterEverythingAboutSPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpjAngkut_LokasiAngkut_LokasiAngkutID",
                table: "SpjAngkut");

            migrationBuilder.DropForeignKey(
                name: "FK_SpjAngkut_LokasiBuang_LokasiBuangID",
                table: "SpjAngkut");

            migrationBuilder.DropIndex(
                name: "IX_SpjAngkut_LokasiAngkutID",
                table: "SpjAngkut");

            migrationBuilder.DropIndex(
                name: "IX_SpjAngkut_LokasiBuangID",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "BeratSampah",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "LokasiAngkutID",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "LokasiBuangID",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "TglAngkut",
                table: "SpjAngkut");

            migrationBuilder.AddColumn<long>(
                name: "KendaraanID",
                table: "SpjAngkut",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "NoPintu",
                table: "SpjAngkut",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoPolisi",
                table: "SpjAngkut",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoSPJ",
                table: "SpjAngkut",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailSpj",
                columns: table => new
                {
                    DetailSpjID = table.Column<Guid>(type: "uuid", nullable: false),
                    SpjAngkutID = table.Column<Guid>(type: "uuid", nullable: false),
                    LokasiAngkutID = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaLokasi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    KotaAngkut = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    KecamatanAngkut = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    KelurahanAngkut = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    LokasiBuangID = table.Column<int>(type: "integer", nullable: false),
                    NamaLokasiBuang = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BeratSampah = table.Column<int>(type: "integer", nullable: false),
                    TglAngkut = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailSpj", x => x.DetailSpjID);
                    table.ForeignKey(
                        name: "FK_DetailSpj_LokasiAngkut_LokasiAngkutID",
                        column: x => x.LokasiAngkutID,
                        principalTable: "LokasiAngkut",
                        principalColumn: "LokasiAngkutID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailSpj_LokasiBuang_LokasiBuangID",
                        column: x => x.LokasiBuangID,
                        principalTable: "LokasiBuang",
                        principalColumn: "LokasiBuangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailSpj_SpjAngkut_SpjAngkutID",
                        column: x => x.SpjAngkutID,
                        principalTable: "SpjAngkut",
                        principalColumn: "SpjAngkutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpjAngkut_KendaraanID",
                table: "SpjAngkut",
                column: "KendaraanID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpj_LokasiAngkutID",
                table: "DetailSpj",
                column: "LokasiAngkutID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpj_LokasiBuangID",
                table: "DetailSpj",
                column: "LokasiBuangID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSpj_SpjAngkutID",
                table: "DetailSpj",
                column: "SpjAngkutID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpjAngkut_Kendaraan_KendaraanID",
                table: "SpjAngkut",
                column: "KendaraanID",
                principalTable: "Kendaraan",
                principalColumn: "KendaraanID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpjAngkut_Kendaraan_KendaraanID",
                table: "SpjAngkut");

            migrationBuilder.DropTable(
                name: "DetailSpj");

            migrationBuilder.DropIndex(
                name: "IX_SpjAngkut_KendaraanID",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "KendaraanID",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "NoPintu",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "NoPolisi",
                table: "SpjAngkut");

            migrationBuilder.DropColumn(
                name: "NoSPJ",
                table: "SpjAngkut");

            migrationBuilder.AddColumn<int>(
                name: "BeratSampah",
                table: "SpjAngkut",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LokasiAngkutID",
                table: "SpjAngkut",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LokasiBuangID",
                table: "SpjAngkut",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "TglAngkut",
                table: "SpjAngkut",
                type: "date",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpjAngkut_LokasiAngkutID",
                table: "SpjAngkut",
                column: "LokasiAngkutID");

            migrationBuilder.CreateIndex(
                name: "IX_SpjAngkut_LokasiBuangID",
                table: "SpjAngkut",
                column: "LokasiBuangID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpjAngkut_LokasiAngkut_LokasiAngkutID",
                table: "SpjAngkut",
                column: "LokasiAngkutID",
                principalTable: "LokasiAngkut",
                principalColumn: "LokasiAngkutID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpjAngkut_LokasiBuang_LokasiBuangID",
                table: "SpjAngkut",
                column: "LokasiBuangID",
                principalTable: "LokasiBuang",
                principalColumn: "LokasiBuangID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
