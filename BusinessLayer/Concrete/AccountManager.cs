using BusinessLayer.Abstract;
using BusinessLayer.ViewModels.KullaniciVM;
using DataAccessLayer.Abstract;
using Entities.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AccountManager:IAccountManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountManager(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> KullaniciContex(KullaniciVM user)
        {
            var kullanici = await _userRepository.Table
                                  .Include(u=>u.UserRoles)
                                  .ThenInclude(ur=>ur.Role)
                                  .FirstOrDefaultAsync(u=>u.UserName == user.KullaniciAdi&&u.Password==user.Sifre);

            if (kullanici != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,kullanici.UserName),
                    new Claim(ClaimTypes.GivenName,"Basic"),
                };
                foreach (var item in kullanici.UserRoles)
                {
                    new Claim(ClaimTypes.Role, item.Role.RoleName);
                }
                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimIndentity), new AuthenticationProperties());
                return true;
            }
            return false;
        }
    }
}
