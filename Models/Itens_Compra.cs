namespace TCC_2025.Models
{
    public class Itens_Compra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
