using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateJunctionIzinKendaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IzinAngkutKendaraan",
                columns: table => new
                {
                    IzinAngkutsIzinAngkutID = table.Column<Guid>(type: "uuid", nullable: false),
                    KendaraansKendaraanID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinAngkutKendaraan", x => new { x.IzinAngkutsIzinAngkutID, x.KendaraansKendaraanID });
                    table.ForeignKey(
                        name: "FK_IzinAngkutKendaraan_IzinAngkut_IzinAngkutsIzinAngkutID",
                        column: x => x.IzinAngkutsIzinAngkutID,
                        principalTable: "IzinAngkut",
                        principalColumn: "IzinAngkutID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzinAngkutKendaraan_Kendaraan_KendaraansKendaraanID",
                        column: x => x.KendaraansKendaraanID,
                        principalTable: "Kendaraan",
                        principalColumn: "KendaraanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzinAngkutKendaraan_KendaraansKendaraanID",
                table: "IzinAngkutKendaraan",
                column: "KendaraansKendaraanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinAngkutKendaraan");
        }
    }
}
