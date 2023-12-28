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
            return View("Register");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(KullaniciHesap ekleKullanici)
        {
            var check = hastaneCS.KullaniciHesaplar.FirstOrDefault(x => x.Email == ekleKullanici.Email && x.Password == ekleKullanici.Password);

            if (check != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.error = "Kayıtlı kullanıcı bulunamadı!";
            return View();
        }
    }
}
