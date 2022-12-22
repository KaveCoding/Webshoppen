using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class BeställningUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Betalsätter_BetalsättId",
                table: "Beställningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Produkter_ProduktId",
                table: "Beställningar");

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "Beställningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KundId",
                table: "Beställningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BetalsättId",
                table: "Beställningar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Betalsätter_BetalsättId",
                table: "Beställningar",
                column: "BetalsättId",
                principalTable: "Betalsätter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar",
                column: "KundId",
                principalTable: "Kunder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Produkter_ProduktId",
                table: "Beställningar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Betalsätter_BetalsättId",
                table: "Beställningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Produkter_ProduktId",
                table: "Beställningar");

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "Beställningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KundId",
                table: "Beställningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BetalsättId",
                table: "Beställningar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Betalsätter_BetalsättId",
                table: "Beställningar",
                column: "BetalsättId",
                principalTable: "Betalsätter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar",
                column: "KundId",
                principalTable: "Kunder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Produkter_ProduktId",
                table: "Beställningar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");
        }
    }
}
