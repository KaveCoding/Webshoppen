using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class beställning1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeställningId",
                table: "Produkter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeställningId",
                table: "Kunder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Beställningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    Summa = table.Column<float>(type: "real", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beställningar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_BeställningId",
                table: "Produkter",
                column: "BeställningId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunder_BeställningId",
                table: "Kunder",
                column: "BeställningId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kunder_Beställningar_BeställningId",
                table: "Kunder",
                column: "BeställningId",
                principalTable: "Beställningar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Beställningar_BeställningId",
                table: "Produkter",
                column: "BeställningId",
                principalTable: "Beställningar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunder_Beställningar_BeställningId",
                table: "Kunder");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Beställningar_BeställningId",
                table: "Produkter");

            migrationBuilder.DropTable(
                name: "Beställningar");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_BeställningId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Kunder_BeställningId",
                table: "Kunder");

            migrationBuilder.DropColumn(
                name: "BeställningId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "BeställningId",
                table: "Kunder");
        }
    }
}
