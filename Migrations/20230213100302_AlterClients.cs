using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PIC",
                table: "Clients",
                type: "character varying(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(75)",
                oldMaxLength: 75,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoHpPIC",
                table: "Clients",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DokumenKTP",
                table: "Clients",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DokumenNIB",
                table: "Clients",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DokumenNPWP",
                table: "Clients",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIK",
                table: "Clients",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NPWP",
                table: "Clients",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DokumenKTP",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DokumenNIB",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DokumenNPWP",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "NIK",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "NPWP",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "PIC",
                table: "Clients",
                type: "character varying(75)",
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "NoHpPIC",
                table: "Clients",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);
        }
    }
}
