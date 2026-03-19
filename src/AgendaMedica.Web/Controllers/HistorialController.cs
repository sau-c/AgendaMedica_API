using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Web.Controllers
{
    public class HistorialController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
