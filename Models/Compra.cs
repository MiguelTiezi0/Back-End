namespace TCC_2025.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string? Descricao { get; set; }
        public int QuantidadeDeProduto { get; set; }
        public int QuantidadeAtual { get; set; }
        public decimal ValorDaCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public int Itens_Compra { get; set; }
    }
}
