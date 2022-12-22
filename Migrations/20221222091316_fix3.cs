using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
