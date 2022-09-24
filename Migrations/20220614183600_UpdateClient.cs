using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class UpdateClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Clients",
                newName: "ClientName");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "UserName");
        }
    }
}
