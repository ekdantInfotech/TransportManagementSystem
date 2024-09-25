using Microsoft.AspNetCore.Mvc;

namespace Transport.WebAppMvc.Areas.Account.Controllers
{
    [Area("Account")]
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
