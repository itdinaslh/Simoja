using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterClientJenis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_JenisUsaha_JenisUsahaID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_JenisUsahaID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "JenisUsahaID",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientJenisUsaha",
                columns: table => new
                {
                    ClientsClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    JenisUsahasJenisUsahaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientJenisUsaha", x => new { x.ClientsClientID, x.JenisUsahasJenisUsahaID });
                    table.ForeignKey(
                        name: "FK_ClientJenisUsaha_Clients_ClientsClientID",
                        column: x => x.ClientsClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientJenisUsaha_JenisUsaha_JenisUsahasJenisUsahaID",
                        column: x => x.JenisUsahasJenisUsahaID,
                        principalTable: "JenisUsaha",
                        principalColumn: "JenisUsahaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientJenisUsaha_JenisUsahasJenisUsahaID",
                table: "ClientJenisUsaha",
                column: "JenisUsahasJenisUsahaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientJenisUsaha");

            migrationBuilder.AddColumn<int>(
                name: "JenisUsahaID",
                table: "Clients",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_JenisUsahaID",
                table: "Clients",
                column: "JenisUsahaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_JenisUsaha_JenisUsahaID",
                table: "Clients",
                column: "JenisUsahaID",
                principalTable: "JenisUsaha",
                principalColumn: "JenisUsahaID");
        }
    }
}
