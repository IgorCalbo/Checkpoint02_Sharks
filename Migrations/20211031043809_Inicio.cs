using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharks.Checkpoint02.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Editora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dt_Inicio = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Editora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Dt_Lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paginas = table.Column<int>(type: "int", nullable: false),
                    Infantil = table.Column<bool>(type: "bit", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    EditoraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Livro_Tbl_Editora_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Tbl_Editora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Escritor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Escritor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Escritor_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Livro_Escritor",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false),
                    EscritorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Livro_Escritor", x => new { x.EscritorId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_Tbl_Livro_Escritor_Tbl_Escritor_EscritorId",
                        column: x => x.EscritorId,
                        principalTable: "Tbl_Escritor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Livro_Escritor_Tbl_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Tbl_Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Escritor_EnderecoId",
                table: "Tbl_Escritor",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Livro_EditoraId",
                table: "Tbl_Livro",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Livro_Escritor_LivroId",
                table: "Tbl_Livro_Escritor",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Livro_Escritor");

            migrationBuilder.DropTable(
                name: "Tbl_Escritor");

            migrationBuilder.DropTable(
                name: "Tbl_Livro");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");

            migrationBuilder.DropTable(
                name: "Tbl_Editora");
        }
    }
}
