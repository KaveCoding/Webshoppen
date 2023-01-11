using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Demo_many2many2.Migrations
{
    public partial class test2 : Migration
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
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VarukorgId = table.Column<int>(type: "int", nullable: false),
                    BetalsättId = table.Column<int>(type: "int", nullable: false),
                    KundId = table.Column<int>(type: "int", nullable: false),
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beställningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beställningar_Betalsätter_BetalsättId",
                        column: x => x.BetalsättId,
                        principalTable: "Betalsätter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beställningar_Kunder_KundId",
                        column: x => x.KundId,
                        principalTable: "Kunder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beställningar_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_Beställningar_Varukorgar_VarukorgId",
                    //    column: x => x.VarukorgId,
                    //    principalTable: "Varukorgar",
                    //    principalColumn: "VarukorgId",
                    //    onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_BetalsättId",
                table: "Beställningar",
                column: "BetalsättId");

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_KundId",
                table: "Beställningar",
                column: "KundId");

            migrationBuilder.CreateIndex(
                name: "IX_Beställningar_ProduktId",
                table: "Beställningar",
                column: "ProduktId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Beställningar_VarukorgId",
            //    table: "Beställningar",
            //    column: "VarukorgId");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
