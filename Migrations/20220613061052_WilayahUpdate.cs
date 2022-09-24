using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class WilayahUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinsi",
                columns: table => new
                {
                    ProvinsiID = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    NamaProvinsi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HcKey = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    KodeNegara = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinsi", x => x.ProvinsiID);
                });

            migrationBuilder.CreateTable(
                name: "Kabupaten",
                columns: table => new
                {
                    KabupatenID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NamaKabupaten = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    IsKota = table.Column<bool>(type: "boolean", nullable: false),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ProvinsiID = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kabupaten", x => x.KabupatenID);
                    table.ForeignKey(
                        name: "FK_Kabupaten_Provinsi_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "Provinsi",
                        principalColumn: "ProvinsiID");
                });

            migrationBuilder.CreateTable(
                name: "Kecamatan",
                columns: table => new
                {
                    KecamatanID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NamaKecamatan = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    KabupatenID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kecamatan", x => x.KecamatanID);
                    table.ForeignKey(
                        name: "FK_Kecamatan_Kabupaten_KabupatenID",
                        column: x => x.KabupatenID,
                        principalTable: "Kabupaten",
                        principalColumn: "KabupatenID");
                });

            migrationBuilder.CreateTable(
                name: "Kelurahan",
                columns: table => new
                {
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    NamaKelurahan = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    KecamatanID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelurahan", x => x.KelurahanID);
                    table.ForeignKey(
                        name: "FK_Kelurahan_Kecamatan_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "Kecamatan",
                        principalColumn: "KecamatanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kabupaten_ProvinsiID",
                table: "Kabupaten",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_Kecamatan_KabupatenID",
                table: "Kecamatan",
                column: "KabupatenID");

            migrationBuilder.CreateIndex(
                name: "IX_Kelurahan_KecamatanID",
                table: "Kelurahan",
                column: "KecamatanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kelurahan");

            migrationBuilder.DropTable(
                name: "Kecamatan");

            migrationBuilder.DropTable(
                name: "Kabupaten");

            migrationBuilder.DropTable(
                name: "Provinsi");
        }
    }
}
