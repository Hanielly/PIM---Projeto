using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techFarm.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    ID_Fornecedores = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.ID_Fornecedores);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    ID_Funcionarios = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Funcao = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.ID_Funcionarios);
                });

            migrationBuilder.CreateTable(
                name: "Sementes",
                columns: table => new
                {
                    ID_Sementes = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeGrao = table.Column<string>(type: "TEXT", nullable: false),
                    KG = table.Column<double>(type: "REAL", nullable: false),
                    ID_Fornecedores = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sementes", x => x.ID_Sementes);
                    table.ForeignKey(
                        name: "FK_Sementes_Fornecedores_ID_Fornecedores",
                        column: x => x.ID_Fornecedores,
                        principalTable: "Fornecedores",
                        principalColumn: "ID_Fornecedores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotesGraos",
                columns: table => new
                {
                    ID_LotesGraos = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoDeGrao = table.Column<string>(type: "TEXT", nullable: false),
                    QuantidadeKG = table.Column<double>(type: "REAL", nullable: false),
                    ID_Sementes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotesGraos", x => x.ID_LotesGraos);
                    table.ForeignKey(
                        name: "FK_LotesGraos_Sementes_ID_Sementes",
                        column: x => x.ID_Sementes,
                        principalTable: "Sementes",
                        principalColumn: "ID_Sementes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    ID_Vendas = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDaVenda = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuantidadeKGVendida = table.Column<double>(type: "REAL", nullable: false),
                    ID_LotesGraos = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Funcionarios = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.ID_Vendas);
                    table.ForeignKey(
                        name: "FK_Vendas_Funcionarios_ID_Funcionarios",
                        column: x => x.ID_Funcionarios,
                        principalTable: "Funcionarios",
                        principalColumn: "ID_Funcionarios",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Vendas_LotesGraos_ID_LotesGraos",
                        column: x => x.ID_LotesGraos,
                        principalTable: "LotesGraos",
                        principalColumn: "ID_LotesGraos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LotesGraos_ID_Sementes",
                table: "LotesGraos",
                column: "ID_Sementes");

            migrationBuilder.CreateIndex(
                name: "IX_Sementes_ID_Fornecedores",
                table: "Sementes",
                column: "ID_Fornecedores");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ID_Funcionarios",
                table: "Vendas",
                column: "ID_Funcionarios");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ID_LotesGraos",
                table: "Vendas",
                column: "ID_LotesGraos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "LotesGraos");

            migrationBuilder.DropTable(
                name: "Sementes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
