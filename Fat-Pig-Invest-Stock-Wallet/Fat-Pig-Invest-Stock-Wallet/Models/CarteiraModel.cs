using Fat_Pig_Invest_Stock_Wallet.Data;

namespace Fat_Pig_Invest_Stock_Wallet.Models
{
    public class CarteiraModel
    {
        private readonly FatPigInvestContext _context;

        public CarteiraModel(FatPigInvestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carteira>> carteira()
        {
            var ordens = from o in _context.Ordens
                         group o by o.Acao.Ticker into Dados
                         select new Carteira
                         {
                            Acao = Dados.First().Acao.Ticker,
                            Quantidade = Dados.Sum(qtd => 
                                qtd.TipoOrdem=='C'? qtd.Quantidade : (-1)*qtd.Quantidade ),
                            Total = Dados.Sum(valor => 
                                valor.TipoOrdem=='C'? 
                                valor.Quantidade * valor.PrecoUnitario :
                                valor.Quantidade * valor.PrecoUnitario * (-1)
                                )
                         };

            List<Carteira> aux = ordens.ToList() as List<Carteira>;

            return aux;
        }
    }
}
