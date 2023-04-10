using Microsoft.AspNetCore.Mvc;

namespace Front_to_Back.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
