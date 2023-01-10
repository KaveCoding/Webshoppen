using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class produktUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Leverantörer_LeverantörId",
                table: "Produkter");

            migrationBuilder.AlterColumn<int>(
                name: "LeverantörId",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter",
                column: "KategoriId",
                principalTable: "Kategorier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Leverantörer_LeverantörId",
                table: "Produkter",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Leverantörer_LeverantörId",
                table: "Produkter");

            migrationBuilder.AlterColumn<int>(
                name: "LeverantörId",
                table: "Produkter",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Produkter",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter",
                column: "KategoriId",
                principalTable: "Kategorier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Leverantörer_LeverantörId",
                table: "Produkter",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id");
        }
    }
}
