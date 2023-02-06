using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateGuidForIzinAngkut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIBPath",
                table: "IzinAngkut");

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueId",
                table: "IzinAngkut",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "IzinAngkut");

            migrationBuilder.AddColumn<string>(
                name: "NIBPath",
                table: "IzinAngkut",
                type: "text",
                nullable: true);
        }
    }
}
