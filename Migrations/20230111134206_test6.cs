using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Leverantörer_LeverantörId",
                table: "Beställningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Varukorgar_VarukorgId",
                table: "Beställningar");

            migrationBuilder.DropIndex(
                name: "IX_Beställningar_VarukorgId",
                table: "Beställningar");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Beställningar_Leverantörer_LeverantörId",
            //    table: "Beställningar");

            //migrationBuilder.AlterColumn<int>(
            //    name: "LeverantörId",
            //    table: "Beställningar",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AddColumn<int>(
            //    name: "Leverantör",
            //    table: "Beställningar",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Beställningar_VarukorgId",
            //    table: "Beställningar",
            //    column: "VarukorgId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Beställningar_Leverantörer_LeverantörId",
            //    table: "Beställningar",
            //    column: "LeverantörId",
            //    principalTable: "Leverantörer",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Beställningar_Varukorgar_VarukorgId",
            //    table: "Beställningar",
            //    column: "VarukorgId",
            //    principalTable: "Varukorgar",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
