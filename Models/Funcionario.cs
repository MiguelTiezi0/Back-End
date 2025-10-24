namespace TCC_2025.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Endereço { get; set; }

        public DateTime DataContratação { get; set; }
        public string? Telefone { get; set; }
        public decimal Salário { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool Ativo { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public NivelAcesso NivelAcesso { get; set; }

    }
}
