using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LagerStatusar_Produkter_ProduktId",
                table: "LagerStatusar");

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "LagerStatusar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LagerStatusar_Produkter_ProduktId",
                table: "LagerStatusar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LagerStatusar_Produkter_ProduktId",
                table: "LagerStatusar");

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "LagerStatusar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LagerStatusar_Produkter_ProduktId",
                table: "LagerStatusar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");
        }
    }
}
