using Microsoft.AspNetCore.Mvc;

namespace CraftingTableBackend.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
