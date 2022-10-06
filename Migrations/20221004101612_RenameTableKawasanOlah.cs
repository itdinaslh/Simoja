using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class RenameTableKawasanOlah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailOlah");

            migrationBuilder.CreateTable(
                name: "IzinOlah",
                columns: table => new
                {
                    DetailOlahId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinOlah", x => x.DetailOlahId);
                    table.ForeignKey(
                        name: "FK_IzinOlah_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzinOlah_ClientId",
                table: "IzinOlah",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzinOlah");

            migrationBuilder.CreateTable(
                name: "DetailOlah",
                columns: table => new
                {
                    DetailOlahId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DokumenIzinPath = table.Column<string>(type: "text", nullable: true),
                    NIB = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NIBPath = table.Column<string>(type: "text", nullable: true),
                    NoIzinUsaha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TglAkhirIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    TglTerbitIzin = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOlah", x => x.DetailOlahId);
                    table.ForeignKey(
                        name: "FK_DetailOlah_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailOlah_ClientId",
                table: "DetailOlah",
                column: "ClientId",
                unique: true);
        }
    }
}
