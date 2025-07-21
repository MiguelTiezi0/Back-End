using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class FormaPagPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaDePagamento",
                table: "Pagamento",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaDePagamento",
                table: "Pagamento");
        }
    }
}
