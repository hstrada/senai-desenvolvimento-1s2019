using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.Games.Repository.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    EstudioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeEstudio = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.EstudioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(150)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    JogoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Descricao = table.Column<string>(type: "Text", nullable: false),
                    DataLancamento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    EstudioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.JogoId);
                    table.ForeignKey(
                        name: "FK_Jogos_Estudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudios",
                        principalColumn: "EstudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudios",
                columns: new[] { "EstudioId", "NomeEstudio" },
                values: new object[,]
                {
                    { 1, "Square Enix" },
                    { 2, "Blizzard" },
                    { 3, "Rockstar Studios" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Email", "Senha", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "admin", "ADMINISTRADOR" },
                    { 2, "cliente@cliente.com", "cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "JogoId", "DataLancamento", "Descricao", "EstudioId", "Nome", "Valor" },
                values: new object[] { 1, new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã", 2, "Diablo 3", 99.00m });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "JogoId", "DataLancamento", "Descricao", "EstudioId", "Nome", "Valor" },
                values: new object[] { 2, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogo eletrônico de ação-aventura western", 3, "Red Dead Redemption II", 120.00m });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_EstudioId",
                table: "Jogos",
                column: "EstudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estudios");
        }
    }
}
