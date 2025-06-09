namespace TCC_2025.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
        public int TotalDeItens { get; set; }
        public decimal ValorTotal { get; set; }
        public string[]? FormaDePagamento { get; set; }
        public DateTime DataVenda { get; set; }

     


    }
}
