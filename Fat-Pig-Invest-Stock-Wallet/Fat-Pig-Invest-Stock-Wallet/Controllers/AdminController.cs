using Fat_Pig_Invest_Stock_Wallet.Data;
using Microsoft.AspNetCore.Mvc;

namespace Fat_Pig_Invest_Stock_Wallet.Controllers
{
    public class AdminController : Controller
    {
        private readonly FatPigInvestContext _context;

        public AdminController(FatPigInvestContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Data for stock pie chart */
        public async Task<JsonResult> pvDistribuicaoAcoes()
        {
            var ordens = from o in _context.Ordens
                         select new
                         {
                             acao = o.Acao.Ticker,                             
                             tipo = o.TipoOrdem,
                             preco = o.PrecoUnitario,
                             quantidade = (o.TipoOrdem == 'C') ? o.Quantidade : (-1)*o.Quantidade
                         };

            var distribuicao = from o in ordens
                               group o by o.acao into dados
                               select new
                               {
                                   acao = dados.First().acao,
                                   quantidade = dados.Sum(qtd => qtd.quantidade),
                                   total = dados.Sum(value => value.quantidade * value.preco)
                               };         
                        
            return Json(distribuicao.Where(d => d.quantidade > 0).ToList());
        }

        /* Data for stocks table */
        public async Task<PartialViewResult> pvPosicaoAcionaria()
        {
            return null;
        }

        /* Data for stock wallet evolution */
        public async Task<PartialViewResult> pvEvolucaoPatrimonial()
        {
            return null;
        }

        /* Data for stock earnings */
        public async Task<PartialViewResult> pvProventos()
        {
            return null;
        }


    }
}
