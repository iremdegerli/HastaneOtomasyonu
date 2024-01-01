using HastaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyonu.Controllers
{
	public class RandevuController : Controller
	{
			private readonly HastaneCS hastaneCS;

			public RandevuController(HastaneCS hastaneCS)
			{
				this.hastaneCS = hastaneCS;
			}
			public async Task<IActionResult> Index(Randevu ekleKullanici)
			{
            var randevu = new Randevu()
				{
					RandevuId = ekleKullanici.RandevuId,
                    Tc = ekleKullanici.Tc,
                    HastalarAd = ekleKullanici.HastalarAd,
					HastalarSoyad = ekleKullanici.HastalarSoyad,
					DoktorlarAd = ekleKullanici.DoktorlarAd,
					DoktorlarSoyad = ekleKullanici.DoktorlarSoyad,
					RandevuTarih = ekleKullanici.RandevuTarih,
					RandevuSaati = ekleKullanici.RandevuSaati,
				};

				await hastaneCS.Randevular.AddAsync(randevu);
				await hastaneCS.SaveChangesAsync();
				ViewBag.correct = "Kayıt başarıyla tamamlandı! Giriş yapabilmek için \"Giriş Yap\" sayfasına geçiniz.";
				return View("Index");

			}
		}
	}
