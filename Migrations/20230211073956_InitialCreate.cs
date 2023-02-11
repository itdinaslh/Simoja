using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    FlagID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlagName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.FlagID);
                });

            migrationBuilder.CreateTable(
                name: "JenisKegiatan",
                columns: table => new
                {
                    JenisKegiatanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prefix = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    NamaKegiatan = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisKegiatan", x => x.JenisKegiatanID);
                });

            migrationBuilder.CreateTable(
                name: "JenisKendaraan",
                columns: table => new
                {
                    JenisKendaraanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GlobalId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NamaJenis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisKendaraan", x => x.JenisKendaraanID);
                });

            migrationBuilder.CreateTable(
                name: "PihakAngkut",
                columns: table => new
                {
                    PihakAngkutID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaPihak = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PihakAngkut", x => x.PihakAngkutID);
                });

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
                name: "StatusKelola",
                columns: table => new
                {
                    StatusKelolaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusKelola", x => x.StatusKelolaID);
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

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Telp = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Fax = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Alamat = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JenisUsahaID = table.Column<int>(type: "integer", nullable: true),
                    PenanggungJawab = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    PIC = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    NoHpPIC = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    NIB = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    FlagID = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Flags_FlagID",
                        column: x => x.FlagID,
                        principalTable: "Flags",
                        principalColumn: "FlagID");
                    table.ForeignKey(
                        name: "FK_Clients_Kelurahan_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID");
                });

            migrationBuilder.CreateTable(
                name: "IzinAngkut",
                columns: table => new
                {
                    IzinAngkutID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    JmlAngkutan = table.Column<int>(type: "integer", nullable: false),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    UniqueID = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinAngkut", x => x.IzinAngkutID);
                    table.ForeignKey(
                        name: "FK_IzinAngkut_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzinKawasan",
                columns: table => new
                {
                    IzinKawasanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "IzinOlah",
                columns: table => new
                {
                    IzinOlahID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinOlah", x => x.IzinOlahID);
                    table.ForeignKey(
                        name: "FK_IzinOlah_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kendaraan",
                columns: table => new
                {
                    KendaraanID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    UniqueID = table.Column<Guid>(type: "uuid", nullable: false),
                    NoPolisi = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    NoPintu = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    JenisKendaraanId = table.Column<int>(type: "integer", nullable: false),
                    TahunPembuatan = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    TglSTNK = table.Column<DateOnly>(type: "date", nullable: false),
                    TglKIR = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenSTNK = table.Column<string>(type: "text", nullable: true),
                    DokumenKIR = table.Column<string>(type: "text", nullable: true),
                    FotoKendaraan = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kendaraan", x => x.KendaraanID);
                    table.ForeignKey(
                        name: "FK_Kendaraan_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kendaraan_JenisKendaraan_JenisKendaraanId",
                        column: x => x.JenisKendaraanId,
                        principalTable: "JenisKendaraan",
                        principalColumn: "JenisKendaraanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LokasiAngkut",
                columns: table => new
                {
                    LokasiAngkutID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    UniqueID = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaLokasi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    TglAwalKontrak = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirKontrak = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DokumenPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokasiAngkut", x => x.LokasiAngkutID);
                    table.ForeignKey(
                        name: "FK_LokasiAngkut_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LokasiAngkut_Kelurahan_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FlagID",
                table: "Clients",
                column: "FlagID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_KelurahanID",
                table: "Clients",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinAngkut_ClientID",
                table: "IzinAngkut",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IzinKawasan_ClientID",
                table: "IzinKawasan",
                column: "ClientID",
                unique: true);

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
                name: "IX_IzinOlah_ClientID",
                table: "IzinOlah",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JenisKendaraan_GlobalId",
                table: "JenisKendaraan",
                column: "GlobalId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_ClientID",
                table: "Kendaraan",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_JenisKendaraanId",
                table: "Kendaraan",
                column: "JenisKendaraanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_UniqueID",
                table: "Kendaraan",
                column: "UniqueID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_ClientID",
                table: "LokasiAngkut",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_KelurahanID",
                table: "LokasiAngkut",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_UniqueID",
                table: "LokasiAngkut",
                column: "UniqueID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinAngkut");

            migrationBuilder.DropTable(
                name: "IzinKawasan");

            migrationBuilder.DropTable(
                name: "IzinOlah");

            migrationBuilder.DropTable(
                name: "Kendaraan");

            migrationBuilder.DropTable(
                name: "LokasiAngkut");

            migrationBuilder.DropTable(
                name: "JenisKegiatan");

            migrationBuilder.DropTable(
                name: "PihakAngkut");

            migrationBuilder.DropTable(
                name: "StatusKelola");

            migrationBuilder.DropTable(
                name: "JenisKendaraan");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Flags");

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
