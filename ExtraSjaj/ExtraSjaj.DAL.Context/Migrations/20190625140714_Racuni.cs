using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtraSjaj.DAL.Context.Migrations
{
    public partial class Racuni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racuni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrijednost = table.Column<double>(nullable: false),
                    Placen = table.Column<bool>(nullable: false),
                    VrijemeKreiranjaRacuna = table.Column<DateTime>(nullable: false),
                    BrojTepiha = table.Column<int>(nullable: false),
                    VrijemePlacanjaRacuna = table.Column<DateTime>(nullable: false),
                    MusterijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racuni_Musterije_MusterijaId",
                        column: x => x.MusterijaId,
                        principalTable: "Musterije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racuni_MusterijaId",
                table: "Racuni",
                column: "MusterijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racuni");
        }
    }
}
