using BusinessLayer.Abstract;
using BusinessLayer.ViewModels.KullaniciVM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Form");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(KullaniciVM user)
        {
            if (ModelState.IsValid)
            {
                var kullanici = await _accountManager.KullaniciContex(user);
                if (kullanici)
                {
                    return RedirectToAction("Index", "Form");
                }
            }
            ModelState.AddModelError("", "Kullanıcı Bilgileri Hatalı");
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
            if (ModelState.IsValid)
            {
                var create=await _accountManager.CreateUser(userCreate);
                if (create)
                {
                    return RedirectToAction("Login");
                }
            }
            ModelState.AddModelError("", "Kullanıcı Adı Kullanılıyor");
            return View(userCreate);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
