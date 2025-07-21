namespace TCC_2025.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
        public int VendaId { get; set; }

        public decimal TotalPago { get; set; }

        public decimal Desconto { get; set; }
        public string[]? FormaDePagamento { get; set; }
        public int ToTalDeVezes { get; set; }
        public DateTime DataPagamento { get; set; }

    }
}
