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
    }
}
