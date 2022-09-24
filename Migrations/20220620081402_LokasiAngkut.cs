using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class LokasiAngkut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LokasiAngkut",
                columns: table => new
                {
                    LokasiAngkutId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    NamaLokasi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    TglAwalKontrak = table.Column<DateOnly>(type: "date", nullable: true),
                    TglAkhirKontrak = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokasiAngkut", x => x.LokasiAngkutId);
                    table.ForeignKey(
                        name: "FK_LokasiAngkut_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LokasiAngkut_Kelurahan_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_ClientId",
                table: "LokasiAngkut",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_KelurahanID",
                table: "LokasiAngkut",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_UniqueId",
                table: "LokasiAngkut",
                column: "UniqueId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LokasiAngkut");
        }
    }
}
