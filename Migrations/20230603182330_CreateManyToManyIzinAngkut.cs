using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateManyToManyIzinAngkut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kendaraan_IzinAngkut_IzinAngkutID",
                table: "Kendaraan");

            migrationBuilder.DropIndex(
                name: "IX_Kendaraan_IzinAngkutID",
                table: "Kendaraan");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientID",
                table: "Kendaraan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_Kendaraan_ClientID",
                table: "Kendaraan",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_IzinAngkutKendaraan_KendaraansKendaraanID",
                table: "IzinAngkutKendaraan",
                column: "KendaraansKendaraanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kendaraan_Clients_ClientID",
                table: "Kendaraan",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kendaraan_Clients_ClientID",
                table: "Kendaraan");

            migrationBuilder.DropTable(
                name: "IzinAngkutKendaraan");

            migrationBuilder.DropIndex(
                name: "IX_Kendaraan_ClientID",
                table: "Kendaraan");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Kendaraan");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_IzinAngkutID",
                table: "Kendaraan",
                column: "IzinAngkutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kendaraan_IzinAngkut_IzinAngkutID",
                table: "Kendaraan",
                column: "IzinAngkutID",
                principalTable: "IzinAngkut",
                principalColumn: "IzinAngkutID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
