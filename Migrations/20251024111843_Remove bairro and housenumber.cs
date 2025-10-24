using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class Removebairroandhousenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "NumeroDaCasa",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Número",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Cliente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Número",
                table: "Cliente",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
