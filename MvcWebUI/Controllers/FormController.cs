using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
