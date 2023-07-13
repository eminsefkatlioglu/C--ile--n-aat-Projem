using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Sefkat.Entity;
using Sefkat.DataAccess;

namespace Sefkat.UI.Controllers
{
    public class LoginController : Controller
    {
        public KContext db;
        public LoginController()
        {
            db = new KContext();
        }
       public IActionResult LoginGiris()
        {
            return View();    
        }
        [HttpPost]
        public async Task<IActionResult> LoginGiris(string Kadi , string Sifre)
        {
            var uyevarmi = db.Login.FirstOrDefault(x => x.Kadi == Kadi && x.Sifre == Sifre);
            if(uyevarmi != null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, Kadi));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Anasayfa", "Yonetim");
            }
            else
            {
                ViewBag.Durum = "HATALI GİRİŞ!!";

                return RedirectToAction("LoginGiris", "Login");
            }
        }
    }
}
