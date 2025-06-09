using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC_2025.Migrations
{
    /// <inheritdoc />
    public partial class correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Venda_Venda_VendaId",
                table: "Itens_Venda");

            migrationBuilder.DropIndex(
                name: "IX_Itens_Venda_VendaId",
                table: "Itens_Venda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Itens_Venda_VendaId",
                table: "Itens_Venda",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Venda_Venda_VendaId",
                table: "Itens_Venda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
