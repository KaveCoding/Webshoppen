using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class fix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeställningProdukt");

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Beställningar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_ProduktId",
                table: "Beställningar",
                column: "ProduktId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beställningar_Produkter_ProduktId",
                table: "Beställningar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Produkter_ProduktId",
                table: "Beställningar");

            migrationBuilder.DropIndex(
                name: "IX_Beställningar_ProduktId",
                table: "Beställningar");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Beställningar");

            migrationBuilder.CreateTable(
                name: "BeställningProdukt",
                columns: table => new
                {
                    BeställningarId = table.Column<int>(type: "int", nullable: false),
                    ProdukterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeställningProdukt", x => new { x.BeställningarId, x.ProdukterId });
                    table.ForeignKey(
                        name: "FK_BeställningProdukt_Beställningar_BeställningarId",
                        column: x => x.BeställningarId,
                        principalTable: "Beställningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeställningProdukt_Produkter_ProdukterId",
                        column: x => x.ProdukterId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeställningProdukt_ProdukterId",
                table: "BeställningProdukt",
                column: "ProdukterId");
        }
    }
}
