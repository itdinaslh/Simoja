using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class DropClientIDFromKendaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kendaraan_Clients_ClientID",
                table: "Kendaraan");

            migrationBuilder.DropIndex(
                name: "IX_Kendaraan_ClientID",
                table: "Kendaraan");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Kendaraan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientID",
                table: "Kendaraan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_ClientID",
                table: "Kendaraan",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kendaraan_Clients_ClientID",
                table: "Kendaraan",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
