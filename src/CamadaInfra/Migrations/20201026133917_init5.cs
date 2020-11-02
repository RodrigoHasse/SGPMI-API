using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CamadaInfra.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimParada",
                table: "Paradas",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFimParada",
                table: "Paradas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
