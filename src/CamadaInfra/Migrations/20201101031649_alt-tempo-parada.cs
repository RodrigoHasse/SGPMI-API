using Microsoft.EntityFrameworkCore.Migrations;

namespace CamadaInfra.Migrations
{
    public partial class alttempoparada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Paradas");

            migrationBuilder.RenameColumn(
                name: "tempoParada",
                table: "Paradas",
                newName: "TempoParada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempoParada",
                table: "Paradas",
                newName: "tempoParada");

            migrationBuilder.AddColumn<string>(
                name: "teste",
                table: "Paradas",
                nullable: true);
        }
    }
}
