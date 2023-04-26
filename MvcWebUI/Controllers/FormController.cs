using BusinessLayer.Abstract;
using BusinessLayer.ViewModels.FormVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles = "Admin,Uye")]
    public class FormController : Controller
    {
        private readonly IFormManager _formManager;

        public FormController(IFormManager formManager)
        {
            _formManager = formManager;
        }

        [HttpGet("form")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> FormList()
        {
            var form = await _formManager.FormGetList();
            return Json(form);
        }
        [HttpPost]
        public async Task<JsonResult> FormCreate(FormCreateVM formCreate)
        {
            await _formManager.CreateForm(formCreate);
            return Json(true);
        }
        [HttpGet("forms/{id}")]
        public async Task<IActionResult> FormMessage(int id)
        {
            return View(await _formManager.GetFormMessage(id));
        }
        [HttpPost]
        public async Task<JsonResult> PostFormMessage(FormMessagePostVM formMessagePost)
        {
            await _formManager.NewFormMessage(formMessagePost);
            return Json(true);
        }

    }
}
