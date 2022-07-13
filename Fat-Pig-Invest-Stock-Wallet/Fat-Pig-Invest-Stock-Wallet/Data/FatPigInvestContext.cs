using Microsoft.EntityFrameworkCore;

namespace Fat_Pig_Invest_Stock_Wallet.Data
{
    public class FatPigInvestContext : DbContext
    {
        public FatPigInvestContext(DbContextOptions<FatPigInvestContext> options) : base(options)
        {
        }
    }
}
