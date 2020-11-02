using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CamadaInfra.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Ligada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Senha = table.Column<string>(maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Logado = table.Column<bool>(nullable: false),
                    UltimoLogin = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    MaquinaId = table.Column<int>(nullable: false),
                    MotivoId = table.Column<int>(nullable: true),
                    DataFimParada = table.Column<DateTime>(nullable: false),
                    TotalParada = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paradas_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paradas_Motivos_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "Motivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paradas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_MaquinaId",
                table: "Paradas",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_MotivoId",
                table: "Paradas",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paradas_UsuarioId",
                table: "Paradas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paradas");

            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DropTable(
                name: "Motivos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
