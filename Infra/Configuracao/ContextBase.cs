using Entitities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }
        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<Fornecedores> Fornecedor { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Unidades> Unidade { get; set; }
        public DbSet<UsuarioEstoque> UsuarioEstoque { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().ToTable("Funcionario").HasKey(t => t.Id);
            modelBuilder.Entity<Produto>().ToTable("Produto").HasKey(t => t.Codigo);

            base.OnModelCreating(modelBuilder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=DESKTOP-BEIRIGO;Initial Catalog=StockKeeper;Integrated Security=False;User ID=sa;Password=123456789;TrustServerCertificate=True";
        }
    }
}