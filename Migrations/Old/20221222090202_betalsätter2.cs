using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class betalsätter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Betalsätter_Beställningar_BeställningId",
                table: "Betalsätter");

            migrationBuilder.DropIndex(
                name: "IX_Betalsätter_BeställningId",
                table: "Betalsätter");

            migrationBuilder.DropColumn(
                name: "BeställningId",
                table: "Betalsätter");

            migrationBuilder.AddColumn<int>(
                name: "BetalsättId",
                table: "Beställningar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_BetalsättId",
                table: "Beställningar",
                column: "BetalsättId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Betalsätter_BetalsättId",
                table: "Beställningar",
                column: "BetalsättId",
                principalTable: "Betalsätter",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Betalsätter_BetalsättId",
                table: "Beställningar");

            migrationBuilder.DropIndex(
                name: "IX_Beställningar_BetalsättId",
                table: "Beställningar");

            migrationBuilder.DropColumn(
                name: "BetalsättId",
                table: "Beställningar");

            migrationBuilder.AddColumn<int>(
                name: "BeställningId",
                table: "Betalsätter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Betalsätter_BeställningId",
                table: "Betalsätter",
                column: "BeställningId");

            migrationBuilder.AddForeignKey(
                name: "FK_Betalsätter_Beställningar_BeställningId",
                table: "Betalsätter",
                column: "BeställningId",
                principalTable: "Beställningar",
                principalColumn: "Id");
        }
    }
}
