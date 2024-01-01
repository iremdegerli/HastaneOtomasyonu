using HastaneOtomasyonu.Models;
using HastaneOtomasyonu.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HastaneOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
		private LanguageService _localization;
		private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
			_localization = localization;
			_logger = logger;
        }
		public IActionResult ChangeLanguage(string culture)
		{
			Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
				{
					Expires = DateTimeOffset.UtcNow.AddYears(1)
				});
			return Redirect(Request.Headers["Referer"].ToString());
		}
		public IActionResult Index()
        {
			ViewBag.Welcome = _localization.Getkey("Welcome").Value;
			var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
			return View();
        }
		public IActionResult Iletisim()
		{
			return View();
		}
		public IActionResult Poliklinik()
		{
			return View();
		}
        public IActionResult IndexG()
        {
			var name = HttpContext.Session.GetString("username");
			ViewBag.username = name;
			return View();
        }
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
