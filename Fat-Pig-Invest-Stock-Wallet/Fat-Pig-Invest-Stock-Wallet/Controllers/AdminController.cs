using Fat_Pig_Invest_Stock_Wallet.Data;
using Fat_Pig_Invest_Stock_Wallet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fat_Pig_Invest_Stock_Wallet.Controllers
{
    public class AdminController : Controller
    {
        private readonly FatPigInvestContext _context;
        private readonly CarteiraModel _carteiraModel;        

        public AdminController(FatPigInvestContext context)
        {
            _context = context;
            _carteiraModel = new CarteiraModel(_context);            
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Data for stock pie chart */
        public async Task<JsonResult> pvDistribuicaoAcoes()
        {            
            var carteira = await _carteiraModel.carteira();
            return Json(carteira.Where(ct => ct.Quantidade>0).ToList());
        }

        /* Partial view for stocks table */
        public async Task<PartialViewResult> pvPosicaoAcionaria()
        {
            var carteira = await _carteiraModel.carteira();
            var dados = carteira.Where(ct => ct.Quantidade > 0).ToList();
            return PartialView("_PosicaoAcionariaPartialView", dados);
        }

        /* Data for stock wallet evolution */
        public async Task<JsonResult> pvEvolucaoPatrimonial()
        {
            var ordens = from o in _context.Ordens
                         group o by o.Nota.DataPregao into Dados
                         select new NotaResumo
                         {
                             DataPregao = Dados.First().Nota.DataPregao,
                             Vendas = Dados.Sum(valor => 
                                valor.TipoOrdem=='V' ?
                                valor.Quantidade * valor.PrecoUnitario :
                                0                             
                             ),
                             Compras = Dados.Sum(valor =>
                                valor.TipoOrdem == 'C' ?
                                valor.Quantidade * valor.PrecoUnitario :
                                0
                             )
                         };
            return Json(ordens.ToList());
        }

        /* Data for stock earnings */
        public async Task<PartialViewResult> pvProventos()
        {
            return null;
        }


    }
}
