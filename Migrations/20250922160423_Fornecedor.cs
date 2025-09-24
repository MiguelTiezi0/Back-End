using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class Fornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FornecedorMarca",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "Produto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Produto");

            migrationBuilder.AddColumn<string>(
                name: "FornecedorMarca",
                table: "Produto",
                type: "TEXT",
                nullable: true);
        }
    }
}
