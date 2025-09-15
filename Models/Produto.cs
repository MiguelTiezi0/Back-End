namespace TCC_2025.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? FornecedorMarca { get; set; }
        public string? Cor { get; set; }
        public string? Tamanho { get; set; }
        public int Quantidade { get; set; }
        public decimal PreçoCusto { get; set; }
        public decimal PreçoVenda { get; set; }
        public bool Ativo { get; set; }
        public int CategoriaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdCompra {  get; set; }

     


    }
}
