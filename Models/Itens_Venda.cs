namespace TCC_2025.Models
{
    public class Itens_Venda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public decimal ValorDoItem { get; set; }
    }
}
