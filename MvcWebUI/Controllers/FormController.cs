using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles = "Admin,Uye")]

    public class FormController : Controller
    {
        [HttpGet("Form")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
