using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateTableSpjAngkut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpjAngkut",
                columns: table => new
                {
                    SpjAngkutID = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    TglSPJ = table.Column<DateOnly>(type: "date", nullable: false),
                    LokasiAngkutID = table.Column<Guid>(type: "uuid", nullable: false),
                    LokasiBuangID = table.Column<int>(type: "integer", nullable: false),
                    BeratSampah = table.Column<int>(type: "integer", nullable: true),
                    TglAngkut = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpjAngkut", x => x.SpjAngkutID);
                    table.ForeignKey(
                        name: "FK_SpjAngkut_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpjAngkut_LokasiAngkut_LokasiAngkutID",
                        column: x => x.LokasiAngkutID,
                        principalTable: "LokasiAngkut",
                        principalColumn: "LokasiAngkutID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpjAngkut_LokasiBuang_LokasiBuangID",
                        column: x => x.LokasiBuangID,
                        principalTable: "LokasiBuang",
                        principalColumn: "LokasiBuangID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpjAngkut_ClientID",
                table: "SpjAngkut",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_SpjAngkut_LokasiAngkutID",
                table: "SpjAngkut",
                column: "LokasiAngkutID");

            migrationBuilder.CreateIndex(
                name: "IX_SpjAngkut_LokasiBuangID",
                table: "SpjAngkut",
                column: "LokasiBuangID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpjAngkut");
        }
    }
}
