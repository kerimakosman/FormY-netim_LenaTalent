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
    public class AccountManager : IAccountManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountManager(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> KullaniciContex(KullaniciVM user)
        {
            var kullanici = await _userRepository.Table
                                  .Include(u => u.UserRoles)
                                  .ThenInclude(ur => ur.Role)
                                  .FirstOrDefaultAsync(u => u.UserName.ToLower() == user.KullaniciAdi.ToLower() && u.Password == user.Sifre);

            if (kullanici != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,kullanici.UserName),
                    new Claim(ClaimTypes.GivenName,"Basic"),
                    //new Claim(ClaimTypes.Role,"Uye"),
                };
                foreach (var item in kullanici.UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.Role.RoleName));
                }
                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimIndentity), new AuthenticationProperties());
                return true;
            }
            return false;
        }
        public async Task<bool> CreateUser(UserCreateVM createUser)
        {
            Role role = await _roleRepository.GetFirstAsync(r => r.RoleName == "Uye");
            User userName = await _userRepository.GetFirstAsync(u => u.UserName.ToLower() == createUser.UserName.ToLower());
            if (userName == null)
            {
                User user = new()
                {
                    Name = createUser.Name,
                    SurName = createUser.SurName,
                    UserName = createUser.UserName,
                    BirthDate = createUser.BirthDate,
                    Gender = createUser.Gender,
                    Password = createUser.Password,
                    UserRoles = new HashSet<UserRole>() { new() { RoleId = role.Id } }
                };
                await _userRepository.AddAsync(user);
                await _userRepository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
