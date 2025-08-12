namespace TCC_2025.Models
{
    public class MovimentoCaixa
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; }

        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }

}
