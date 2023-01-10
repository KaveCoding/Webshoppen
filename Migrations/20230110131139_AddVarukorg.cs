using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class AddVarukorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Varukorgar",
                columns: table => new
                {
                    VarukorgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    ProduktAntal = table.Column<int>(type: "int", nullable: false),
                    ProduktStorlek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summa = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varukorgar", x => x.VarukorgId);
                    table.ForeignKey(
                        name: "FK_Varukorgar_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_ProduktId",
                table: "Varukorgar",
                column: "ProduktId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Varukorgar");
        }
    }
}
