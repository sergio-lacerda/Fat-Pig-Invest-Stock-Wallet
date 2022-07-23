using Microsoft.AspNetCore.Mvc;

namespace Fat_Pig_Invest_Stock_Wallet.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /* Data for stock pie chart */
        public async Task<PartialViewResult> pvDistribuicaoAcoes()
        {
            return null;
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
