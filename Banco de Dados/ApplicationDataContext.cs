using Microsoft.EntityFrameworkCore;
using TCC_2025.Models;

namespace TCC_2025.Banco_de_Dados
{
    public class ApplicationDataContext : DbContext
    {
        
            public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }
            public DbSet<Categoria> Categoria { get; set; }
            public DbSet<Produto> Produto { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Itens_Venda> Itens_Venda { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Caixa> Caixa { get; set; }




    }
}
