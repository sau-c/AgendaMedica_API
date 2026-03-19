using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Web.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
