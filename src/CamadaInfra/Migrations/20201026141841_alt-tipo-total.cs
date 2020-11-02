using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CamadaInfra.Migrations
{
    public partial class alttipototal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalParada",
                table: "Paradas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalParada",
                table: "Paradas",
                nullable: true);
        }
    }
}
