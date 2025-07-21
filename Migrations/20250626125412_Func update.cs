using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class Funcupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Funcionario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDaCasa",
                table: "Funcionario",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "NumeroDaCasa",
                table: "Funcionario");
        }
    }
}
