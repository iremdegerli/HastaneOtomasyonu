using HastaneOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace HastaneOtomasyonu.Controllers
{
	[Authorize(Roles ="Admin")]
	public class AdminController : Controller 
	{
		private readonly HastaneCS hastaneCS;

		public AdminController (HastaneCS hastaneCS)
		{
			this.hastaneCS = hastaneCS;
		}
		public IActionResult Index()
		{
			return View();
		}
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(Admin admin)
		{
			var login = hastaneCS.Admins.Where(x => x.AdminMail == admin.AdminMail).SingleOrDefault();
			if(login!=null&&login.AdminMail==admin.AdminMail&& login.AdminPassword== admin.AdminPassword)
			{
				HttpContext.Session.SetString("eposta", login.AdminId.ToString());
				HttpContext.Session.SetString("eposta", login.AdminMail ?? string.Empty);

				return RedirectToAction("Index", "Admin");
			}
			ViewBag.Uyari = "kullanıcı adı ya da şifre yanlış";
			return View();
		} 

		[HttpGet]
		public IActionResult Doktor()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Doktor(Doktorlar ekleDoktor)
		{
			var doktor = new Doktorlar()
			{
				DoktorlarId = ekleDoktor.DoktorlarId,
				DoktorlarAd = ekleDoktor.DoktorlarAd,
				DoktorlarSoyad = ekleDoktor.DoktorlarSoyad,
				DoktorlarMail = ekleDoktor.DoktorlarMail,
				DoktorlarBolum = ekleDoktor.DoktorlarBolum,
			};

			await hastaneCS.Doktorlars.AddAsync(doktor);
			await hastaneCS.SaveChangesAsync();
			ViewBag.correct = "Doktor başarıyla eklendi!";
			return View("Doktor");
		}

		[HttpGet]
		public async Task<IActionResult> DoktorListele()
		{
			var doktorlar = await hastaneCS.Doktorlars.ToListAsync();
			return View(doktorlar);
		}

		[HttpGet]
		public IActionResult Poliklinik()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Poliklinik(Poliklinik eklePoliklinik)
		{

			var poliklinik = new Poliklinik()
			{
				Poliklinid = eklePoliklinik.Poliklinid,
				PoliklinikAd = eklePoliklinik.PoliklinikAd,
			};

			await hastaneCS.Poliklinikler.AddAsync(poliklinik);
			await hastaneCS.SaveChangesAsync();
			ViewBag.correct = "Poliklinik başarıyla eklendi!";
			return View("Poliklinik");
		}

		[HttpGet]
		public async Task<IActionResult> PoliklinikListele()
		{
			var poliklinikler = await hastaneCS.Poliklinikler.ToListAsync();
			return View(poliklinikler);
        }

		public async Task<IActionResult> Randevu()
		{
			var randevular = await hastaneCS.Randevular.ToListAsync();
			return View(randevular);
		}

		[HttpGet]
		public async Task<IActionResult> Hastalar()
		{
			var hastalar = await hastaneCS.Hastalars.ToListAsync();
			return View(hastalar);
		}

	}
}
