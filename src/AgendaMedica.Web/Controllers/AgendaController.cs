using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Web.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
