using Microsoft.AspNetCore.Mvc;

namespace Fat_Pig_Invest_Stock_Wallet.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
