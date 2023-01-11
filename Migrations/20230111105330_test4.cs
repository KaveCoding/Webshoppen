using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                    name: "IX_Beställningar_VarukorgId",
                    table: "Beställningar",
                    column: "VarukorgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Varukorgar_VarukorgId",
                table: "Beställningar",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
