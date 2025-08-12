namespace TCC_2025.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public bool Aberto { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public decimal ValorAbertura { get; set; }
        public decimal ValorFechamento { get; set; }

        public List<MovimentoCaixa> Movimentos { get; set; } = new();
    }

}
