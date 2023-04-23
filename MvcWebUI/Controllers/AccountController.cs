using BusinessLayer.Abstract;
using BusinessLayer.ViewModels.KullaniciVM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(KullaniciVM user)
        {
            var kullanici=await _accountManager.KullaniciContex(user);
            if (kullanici)
            {
                return RedirectToAction("Index","Form");
            }
            ModelState.AddModelError("","Kullanıcı Bilgileri Hatalı");
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateVM userCreate)
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Giris");
        }
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction("Giris");
        //}
        //public IActionResult AccesDenied()
        //{
        //    return View();
        //}
    }
}
