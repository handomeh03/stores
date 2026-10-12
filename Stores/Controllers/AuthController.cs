using Microsoft.AspNetCore.Mvc;

namespace Stores.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
