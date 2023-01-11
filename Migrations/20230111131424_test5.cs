using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.AddColumn<int>(
                name: "LeverantörId",
                table: "Beställningar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_LeverantörId",
                table: "Beställningar",
                column: "LeverantörId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Leverantörer_LeverantörId",
                table: "Beställningar",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Beställningar_Leverantörer_LeverantörId",
            //    table: "Beställningar");

            //migrationBuilder.DropIndex(
            //    name: "IX_Beställningar_LeverantörId",
            //    table: "Beställningar");

            //migrationBuilder.DropColumn(
            //    name: "Leverantör",
            //    table: "Beställningar");

            //migrationBuilder.DropColumn(
            //    name: "LeverantörId",
            //    table: "Beställningar");
        }
    }
}
