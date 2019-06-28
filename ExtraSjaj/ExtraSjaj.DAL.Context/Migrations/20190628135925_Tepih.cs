using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtraSjaj.DAL.Context.Migrations
{
    public partial class Tepih : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tepisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duzina = table.Column<float>(nullable: false),
                    Sirina = table.Column<float>(nullable: false),
                    Kvadratura = table.Column<float>(nullable: false),
                    RacunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tepisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tepisi_Racuni_RacunId",
                        column: x => x.RacunId,
                        principalTable: "Racuni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tepisi_RacunId",
                table: "Tepisi",
                column: "RacunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tepisi");
        }
    }
}
