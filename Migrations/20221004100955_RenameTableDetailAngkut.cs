using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class RenameTableDetailAngkut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailAngkut");

            migrationBuilder.CreateTable(
                name: "IzinAngkut",
                columns: table => new
                {
                    DetailAngkutId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    JmlAngkutan = table.Column<int>(type: "integer", nullable: false),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    NIBPath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinAngkut", x => x.DetailAngkutId);
                    table.ForeignKey(
                        name: "FK_IzinAngkut_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzinAngkut_ClientId",
                table: "IzinAngkut",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinAngkut");

            migrationBuilder.CreateTable(
                name: "DetailAngkut",
                columns: table => new
                {
                    DetailAngkutId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    JmlAngkutan = table.Column<int>(type: "integer", nullable: false),
                    NIBPath = table.Column<string>(type: "text", nullable: true),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailAngkut", x => x.DetailAngkutId);
                    table.ForeignKey(
                        name: "FK_DetailAngkut_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailAngkut_ClientId",
                table: "DetailAngkut",
                column: "ClientId",
                unique: true);
        }
    }
}
