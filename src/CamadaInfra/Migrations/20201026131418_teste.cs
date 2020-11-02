using Microsoft.EntityFrameworkCore.Migrations;

namespace CamadaInfra.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "teste",
                table: "Paradas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Paradas");
        }
    }
}
