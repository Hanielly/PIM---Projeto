using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techFarm.Migrations
{
    /// <inheritdoc />
    public partial class CampoPrecoVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Vendas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Vendas");
        }
    }
}
