using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class beställningupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

           



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
