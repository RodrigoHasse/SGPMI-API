using Microsoft.EntityFrameworkCore.Migrations;

namespace CamadaInfra.Migrations
{
    public partial class addtempoParada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "tempoParada",
                table: "Paradas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tempoParada",
                table: "Paradas");
        }
    }
}
