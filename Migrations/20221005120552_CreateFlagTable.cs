using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateFlagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlagId",
                table: "Clients",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    FlagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.FlagId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FlagId",
                table: "Clients",
                column: "FlagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Flags_FlagId",
                table: "Clients",
                column: "FlagId",
                principalTable: "Flags",
                principalColumn: "FlagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Flags_FlagId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Flags");

            migrationBuilder.DropIndex(
                name: "IX_Clients_FlagId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FlagId",
                table: "Clients");
        }
    }
}
