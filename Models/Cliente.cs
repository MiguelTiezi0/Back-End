namespace TCC_2025.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Endereço { get; set; }
  
        public string? Telefone { get; set; }
  
        public DateTime DataNascimento { get; set; }
        public decimal LimiteDeCrédito { get; set; }
        public decimal TotalGasto { get; set; }
        public decimal TotalPago { get; set; }
        public decimal TotalDevido { get; set; }

        public string Usuario { get; set; }
        public string Senha { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
    }
}
