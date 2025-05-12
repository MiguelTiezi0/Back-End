namespace TCC_2025.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Endereço { get; set; }
        public int Número { get; set; }
        public string? Telefone { get; set; }
        public string? Bairro { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal LimiteDeCrédito { get; set; }

 
    }
}
