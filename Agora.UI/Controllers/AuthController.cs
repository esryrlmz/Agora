using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agora.UI.Controllers
{
    public class AuthController : Controller
    {
        IUserRepository _repoUser;
        public AuthController(IUserRepository repoUser)
        {
            _repoUser = repoUser;
        }
        public IActionResult Login()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.CssClassName = TempData["CssClassName"];
                ViewBag.Message = TempData["Message"];
            }
            return View((new LoginUser(), new MailDto()));
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind(Prefix = "Item1")] LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            User luser = _repoUser.IsUserLogin(user.UserNameOrMail);
            if (luser != null)
            {
                bool isvalid = BCrypt.Net.BCrypt.Verify(user.Password, luser.Password);
                if (isvalid)
                {
                    //authentication işlemi
                    List<Claim> claims = new List<Claim>() {
                        new Claim("UserName",luser.UserName),
                        new Claim("Mail",luser.UserDetail.Email),
                        new Claim("NameSurname",luser.UserDetail.NameSurname),
                        new Claim("UserID",luser.ID.ToString()),
                        new Claim("Role",luser.Role.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.CssClassName = "danger"; ;
                    ViewBag.Message = "Şifrenizi Hatalı Girdiniz!";
                    return View(user);
                }
            }
            else
            {
                ViewBag.CssClassName = "danger"; ;
                ViewBag.Message = "Kullanıcı Bulunamadı!";
                return View(user);
            }
        }
        public async Task<IActionResult> LogAuth()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
       
    }
}
