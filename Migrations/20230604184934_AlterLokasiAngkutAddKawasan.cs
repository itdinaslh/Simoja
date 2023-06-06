using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simoja.Migrations
{
    public partial class AlterLokasiAngkutAddKawasan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LokasiAngkut_Kelurahan_KelurahanID",
                table: "LokasiAngkut");

            migrationBuilder.DropColumn(
                name: "Alamat",
                table: "LokasiAngkut");

            migrationBuilder.DropColumn(
                name: "IzinAngkutID",
                table: "Kendaraan");

            migrationBuilder.AlterColumn<string>(
                name: "KelurahanID",
                table: "LokasiAngkut",
                type: "character varying(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<Guid>(
                name: "KawasanID",
                table: "LokasiAngkut",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LokasiAngkut_KawasanID",
                table: "LokasiAngkut",
                column: "KawasanID");

            migrationBuilder.AddForeignKey(
                name: "FK_LokasiAngkut_Clients_KawasanID",
                table: "LokasiAngkut",
                column: "KawasanID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LokasiAngkut_Kelurahan_KelurahanID",
                table: "LokasiAngkut",
                column: "KelurahanID",
                principalTable: "Kelurahan",
                principalColumn: "KelurahanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LokasiAngkut_Clients_KawasanID",
                table: "LokasiAngkut");

            migrationBuilder.DropForeignKey(
                name: "FK_LokasiAngkut_Kelurahan_KelurahanID",
                table: "LokasiAngkut");

            migrationBuilder.DropIndex(
                name: "IX_LokasiAngkut_KawasanID",
                table: "LokasiAngkut");

            migrationBuilder.DropColumn(
                name: "KawasanID",
                table: "LokasiAngkut");

            migrationBuilder.AlterColumn<string>(
                name: "KelurahanID",
                table: "LokasiAngkut",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alamat",
                table: "LokasiAngkut",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IzinAngkutID",
                table: "Kendaraan",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_LokasiAngkut_Kelurahan_KelurahanID",
                table: "LokasiAngkut",
                column: "KelurahanID",
                principalTable: "Kelurahan",
                principalColumn: "KelurahanID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
