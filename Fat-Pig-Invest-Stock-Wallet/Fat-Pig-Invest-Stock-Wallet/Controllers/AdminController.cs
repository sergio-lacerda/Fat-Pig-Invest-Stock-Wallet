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

        /* Data for stocks table */
        public async Task<JsonResult> pvPosicaoAcionaria()
        {
            var carteira = await _carteiraModel.carteira();
            return Json(carteira.Where(ct => ct.Quantidade > 0).ToList());
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
