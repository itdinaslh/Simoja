using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterKendaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TahunPembuatan",
                table: "Kendaraan",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueId",
                table: "Kendaraan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TahunPembuatan",
                table: "Kendaraan");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Kendaraan");
        }
    }
}
