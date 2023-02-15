using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Simoja.Migrations
{
    public partial class CreateLokasIzin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Kelurahan_KelurahanID",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PenanggungJawab",
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
                name: "NIB",
                table: "Clients",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KelurahanID",
                table: "Clients",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alamat",
                table: "Clients",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LokasiIzin",
                columns: table => new
                {
                    LokasiIzinID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaLokasi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokasiIzin", x => x.LokasiIzinID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Kelurahan_KelurahanID",
                table: "Clients",
                column: "KelurahanID",
                principalTable: "Kelurahan",
                principalColumn: "KelurahanID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Kelurahan_KelurahanID",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "LokasiIzin");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PenanggungJawab",
                table: "Clients",
                type: "character varying(75)",
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(75)",
                oldMaxLength: 75);

            migrationBuilder.AlterColumn<string>(
                name: "NIB",
                table: "Clients",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "KelurahanID",
                table: "Clients",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Alamat",
                table: "Clients",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Kelurahan_KelurahanID",
                table: "Clients",
                column: "KelurahanID",
                principalTable: "Kelurahan",
                principalColumn: "KelurahanID");
        }
    }
}
