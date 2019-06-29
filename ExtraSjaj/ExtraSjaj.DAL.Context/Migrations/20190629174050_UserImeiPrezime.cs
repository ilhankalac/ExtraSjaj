using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtraSjaj.DAL.Context.Migrations
{
    public partial class UserImeiPrezime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Users");
        }
    }
}
