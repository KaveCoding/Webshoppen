using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beställningar_Kunder_KundId",
                table: "Beställningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kategorier_Produkter_ProduktId",
                table: "Kategorier");

            migrationBuilder.DropForeignKey(
                name: "FK_Leverantörer_Produkter_ProduktId",
                table: "Leverantörer");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Beställningar_BeställningId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Leverantörer_ProduktId",
                table: "Leverantörer");

            migrationBuilder.DropIndex(
                name: "IX_Kategorier_ProduktId",
                table: "Kategorier");

            migrationBuilder.DropIndex(
                name: "IX_Beställningar_KundId",
                table: "Beställningar");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Leverantörer");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Kategorier");

            migrationBuilder.DropColumn(
                name: "KundId",
                table: "Beställningar");

            migrationBuilder.RenameColumn(
                name: "BeställningId",
                table: "Produkter",
                newName: "LeverantörId");

            migrationBuilder.RenameIndex(
                name: "IX_Produkter_BeställningId",
                table: "Produkter",
                newName: "IX_Produkter_LeverantörId");

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Produkter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LagerStatusar",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "LagerStatusar",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LagerStatusar",
                table: "LagerStatusar",
                column: "Id");

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
                name: "IX_Produkter_KategoriId",
                table: "Produkter",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_LagerStatusar_ProduktId",
                table: "LagerStatusar",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_BeställningProdukt_ProdukterId",
                table: "BeställningProdukt",
                column: "ProdukterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LagerStatusar_Produkter_ProduktId",
                table: "LagerStatusar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter",
                column: "KategoriId",
                principalTable: "Kategorier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Leverantörer_LeverantörId",
                table: "Produkter",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LagerStatusar_Produkter_ProduktId",
                table: "LagerStatusar");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Leverantörer_LeverantörId",
                table: "Produkter");

            migrationBuilder.DropTable(
                name: "BeställningProdukt");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LagerStatusar",
                table: "LagerStatusar");

            migrationBuilder.DropIndex(
                name: "IX_LagerStatusar_ProduktId",
                table: "LagerStatusar");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LagerStatusar");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "LagerStatusar");

            migrationBuilder.RenameColumn(
                name: "LeverantörId",
                table: "Produkter",
                newName: "BeställningId");

            migrationBuilder.RenameIndex(
                name: "IX_Produkter_LeverantörId",
                table: "Produkter",
                newName: "IX_Produkter_BeställningId");

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Leverantörer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Kategorier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KundId",
                table: "Beställningar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leverantörer_ProduktId",
                table: "Leverantörer",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorier_ProduktId",
                table: "Kategorier",
                column: "ProduktId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Kategorier_Produkter_ProduktId",
                table: "Kategorier",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leverantörer_Produkter_ProduktId",
                table: "Leverantörer",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Beställningar_BeställningId",
                table: "Produkter",
                column: "BeställningId",
                principalTable: "Beställningar",
                principalColumn: "Id");
        }
    }
}
