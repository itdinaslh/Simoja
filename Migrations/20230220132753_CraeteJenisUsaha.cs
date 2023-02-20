using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CraeteJenisUsaha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JenisUsaha",
                columns: table => new
                {
                    JenisUsahaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Prefix = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    NamaJenis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisUsaha", x => x.JenisUsahaID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_JenisUsaha_JenisUsahaID",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "JenisUsaha");

            migrationBuilder.DropIndex(
                name: "IX_Clients_JenisUsahaID",
                table: "Clients");
        }
    }
}
