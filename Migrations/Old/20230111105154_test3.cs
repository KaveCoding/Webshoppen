using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VarukorgId",
                table: "Varukorgar",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Varukorgar",
                newName: "VarukorgId");
        }
    }
}
