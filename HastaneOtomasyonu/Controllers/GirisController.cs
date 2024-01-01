using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HastaneOtomasyonu.Models;

namespace HastaneOtomasyonu.Controllers
{
    public class GirisController : Controller
    {
        private readonly HastaneCS hastaneCS;

        public GirisController(HastaneCS hastaneCS)
        {
            this.hastaneCS = hastaneCS;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(KullaniciHesap ekleKullanici)
        {

            if (ekleKullanici.Password != ekleKullanici.CPassword)
            {
                ViewBag.error = "Şifreler eşleşmiyor!";
                return View();
            }

            var kullanici = new KullaniciHesap()
            {
                KullaniciHesapId = ekleKullanici.KullaniciHesapId,
                FirstName = ekleKullanici.FirstName,
                LastName = ekleKullanici.LastName,
                Email = ekleKullanici.Email,
                Password = ekleKullanici.Password,
                CPassword = ekleKullanici.CPassword,

            };

            await hastaneCS.KullaniciHesaplar.AddAsync(kullanici);
            await hastaneCS.SaveChangesAsync();
            ViewBag.correct = "Kayıt başarıyla tamamlandı! Giriş yapabilmek için lütfen Giriş Yap sayfasına geçiniz.";
			return RedirectToAction("IndexG", "Home");
		}

		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Login(KullaniciHesap ekleKullanici)
        {
            var check = hastaneCS.KullaniciHesaplar.Where(x => x.Email == ekleKullanici.Email && x.Password == ekleKullanici.Password).FirstOrDefault();
            if (check != null)
            {
                if (check.Email.ToLower() == "b211210038@ogr.sakarya.edu.tr")
                {
                    check.Role = "Admin";
                }
                else
                {
                    check.Role = "Ui";
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, check.FirstName + " " + check.LastName),
                    new Claim(ClaimTypes.Role, "Ui"),
                    new Claim(ClaimTypes.Role, "Admin"),

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

                HttpContext.Session.SetString("username", check.FirstName + " " + check.LastName);
                var name = HttpContext.Session.GetString("username");
                ViewBag.username = name;

                if (check.Role == "Ui")
                {
                    return RedirectToAction("IndexG", "Home");
                }
                else if (check.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            ViewBag.error = "Kayıtlı kullanıcı bulunamadı!";
            return View();

        }

		}
	}
