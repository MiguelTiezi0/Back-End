using System.ComponentModel.DataAnnotations;

namespace TCC_2025.Models
{
    public class DtoMovimentoCaixa
    {
        [Required]
        public decimal Valor { get; set; }

        [Required]
        [RegularExpression("Entrada|Saída", ErrorMessage = "Tipo deve ser 'Entrada' ou 'Saída'")]
        public string Tipo { get; set; }

        public string Descricao { get; set; }
    }
}
