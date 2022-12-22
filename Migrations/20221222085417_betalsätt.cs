using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class betalsätt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Betalsätter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeställningId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betalsätter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Betalsätter_Beställningar_BeställningId",
                        column: x => x.BeställningId,
                        principalTable: "Beställningar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Betalsätter_BeställningId",
                table: "Betalsätter",
                column: "BeställningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Betalsätter");
        }
    }
}
