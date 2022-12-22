using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunder_Beställningar_BeställningId",
                table: "Kunder");

            migrationBuilder.DropIndex(
                name: "IX_Kunder_BeställningId",
                table: "Kunder");

            migrationBuilder.DropColumn(
                name: "BeställningId",
                table: "Kunder");

            migrationBuilder.AddColumn<int>(
                name: "KundId",
                table: "Beställningar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_KundId",
                table: "Beställningar",
                column: "KundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar",
                column: "KundId",
                principalTable: "Kunder",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar");

            migrationBuilder.DropIndex(
                name: "IX_Beställningar_KundId",
                table: "Beställningar");

            migrationBuilder.DropColumn(
                name: "KundId",
                table: "Beställningar");

            migrationBuilder.AddColumn<int>(
                name: "BeställningId",
                table: "Kunder",
                type: "int",
                nullable: true);

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
        }
    }
}
