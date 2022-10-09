using Fat_Pig_Invest_Stock_Wallet.Models;
using Microsoft.EntityFrameworkCore;

namespace Fat_Pig_Invest_Stock_Wallet.Data
{
    public class FatPigInvestContext : DbContext
    {
        public FatPigInvestContext(DbContextOptions<FatPigInvestContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Corretora> Corretoras { get; set; }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<TipoProvento> TiposProvento { get; set; }
        public DbSet<Provento> Proventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProvento>().HasData(
                new TipoProvento { Id = 1, Nome = "Dividendos" },
                new TipoProvento { Id = 2, Nome = "Juros sobre Capital Próprio (JCP)" },
                new TipoProvento { Id = 3, Nome = "Rendimentos FIIs" },
                new TipoProvento { Id = 4, Nome = "Outros" }
            );
        }
    }
}
