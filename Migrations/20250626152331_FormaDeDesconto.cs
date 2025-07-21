using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class FormaDeDesconto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaDeDesconto",
                table: "Venda",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormaDeDesconto",
                table: "Pagamento",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaDeDesconto",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "FormaDeDesconto",
                table: "Pagamento");
        }
    }
}
