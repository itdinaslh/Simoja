using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class ClientAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Telp = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Alamat = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JenisUsahaId = table.Column<int>(type: "integer", nullable: false),
                    PenanggungJawab = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    PIC = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    NoHpPIC = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    NoIzinUsaha = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: true),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: true),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    NIB = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    DokumenNIBPath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Kelurahan_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_KelurahanID",
                table: "Clients",
                column: "KelurahanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
