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

            modelBuilder.Entity<Corretora>().HasData(
                new Corretora { Id = 1, Nome = "FATPIG INVEST DVTM LTDA" },
                new Corretora { Id = 2, Nome = "NU INVEST CORRETORA DE VALORES S.A" },
                new Corretora { Id = 3, Nome = "XP INVESTIMENTOS CCTVM S/A" },
                new Corretora { Id = 4, Nome = "MODAL DTVM LTDA" }
            );

            modelBuilder.Entity<Empresa>().HasData(
                new Empresa { Id = 1, Nome = "ITAUSA", Cnpj = "61.532.644/0001-15" },
                new Empresa { Id = 2, Nome = "PETROBRAS", Cnpj = "33.000.167/0001-01" },
                new Empresa { Id = 3, Nome = "OI SA", Cnpj = "76.535.764/0001-43" },
                new Empresa { Id = 4, Nome = "SANTANDER BR", Cnpj = "90.400.888/0001-42" },
                new Empresa { Id = 5, Nome = "TAESA", Cnpj = "07.859.971/0001-30" }
            );

            modelBuilder.Entity<Acao>().HasData(
                new Acao { Id = 1, EmpresaId = 1, Ticker = "ITSA3" },
                new Acao { Id = 2, EmpresaId = 1, Ticker = "ITSA4" },
                new Acao { Id = 3, EmpresaId = 2, Ticker = "PETR3" },
                new Acao { Id = 4, EmpresaId = 2, Ticker = "PETR4" },
                new Acao { Id = 5, EmpresaId = 3, Ticker = "OIBR3" },
                new Acao { Id = 6, EmpresaId = 4, Ticker = "SANB11" },
                new Acao { Id = 7, EmpresaId = 5, Ticker = "TAEE11" }
            );
        }
    }
}
