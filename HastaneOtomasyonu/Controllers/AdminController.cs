using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu.Controllers
{
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

		public IActionResult Randevu()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Hastalar()
		{
			var hastalar = await hastaneCS.Hastalars.ToListAsync();
			return View(hastalar);
		}

	}
}
