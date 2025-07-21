using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class FormaDeDescontoArumada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaDeDesconto",
                table: "Pagamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaDeDesconto",
                table: "Pagamento",
                type: "TEXT",
                nullable: true);
        }
    }
}
