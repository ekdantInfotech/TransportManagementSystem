using Microsoft.AspNetCore.Mvc;

namespace Transport.WebAppMvc.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
