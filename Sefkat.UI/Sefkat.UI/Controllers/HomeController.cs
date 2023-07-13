using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sefkat.DataAccess;
using Sefkat.Entity;
using Sefkat.UI.Models;

namespace Sefkat.UI.Controllers
{
    public class HomeController : Controller
    {
        public BaseController bs = new BaseController();
        public KContext db;
        public HomeController()
        {
            db = new KContext();
        }
        public IActionResult Index()
        {
            Ayarlar();
            return View(bs.Slider_List());
        }
        public void Ayarlar()
        {
            var ayarbul = db.Ayarlar.FirstOrDefault();
            ViewBag.SiteAdi = ayarbul.SiteAdi;
            ViewBag.Telefon = ayarbul.Telefon;
            ViewBag.Mail = ayarbul.Mail;
            ViewBag.Adres = ayarbul.Adres;
            ViewBag.SliderListele = db.Sliderlar.ToList();
            ViewBag.Hakkimizda = ayarbul.Hakkimizda;
            ViewBag.Bloglar = db.Bloglar.OrderByDescending(x => x.ID).Take(3).ToList();
            ViewBag.Proje = db.Proje.OrderByDescending(x => x.ID).Take(3).ToList();
        }

        [Route("hakkimizda")]
        public IActionResult Hakkimizda()
        {
            Ayarlar();
            return View();
        }
        [Route("baskan-mesaji")]
        public IActionResult Baskanmesajı()
        {
            return View();
        }
        [Route("admin-giris")]
        public IActionResult AdminGiris()
        {
            return View();
        }
        [Route("organizasyon")]
        public IActionResult Org()
        {
            return View();
        }
        public IActionResult BizeUlasin()
        {
            return View();
        }
        [Route("basvuru")]
        public IActionResult Basvuru()
        {
            return View();
        }
        [Route("sirket-profili")]
        public IActionResult ŞirketProfili()
        {
            return View();
        }
        [Route("servis")]
        public IActionResult Servis()
        {
            return View();
        }
        [Route("login-giris")]
        public IActionResult LoginGiris()
        {
            return View();
        }
        [Route("kalite-politikasi")]
        public IActionResult KalitePolitikasi()
        {
            return View();
        }
        [Route("veri-koruma")]
        public IActionResult VeriKoruma()
        {
            return View();
        }
      
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("blog-detay/{id}")]
        public IActionResult BlogDetay(int id)
        {
            Ayarlar();
            var bul = bs.Blog_Bul(id);
            db.SaveChanges();
            return View(bul);
        }
        [Route("proje-detay/{id}")]
        public IActionResult ProjeDetay(int id)
        {
            Ayarlar();
            var bul = bs.Proje_Bul(id);
            db.SaveChanges();
            return View(bul);
        }
        [Route("bloglar")]
        public IActionResult Bloglar()
        {
            Ayarlar();
            return View(bs.Blog_Listesi());
        }
        [Route("proje")]
        public IActionResult Proje()
        {
            Ayarlar();
            return View(bs.Proje_Listele());
        }
        [Route("iletisim")]
        public IActionResult Iletisim()
        {
            Ayarlar();
            return View();
        }

        [HttpPost]
        [Route("iletisim/{id}")]
        public IActionResult Iletisim(Iletisimcs model)
        {
            Ayarlar();
            bool eklendimi = bs.Iletisim_Ekle(model);
            if (eklendimi == true)
            {
                TempData["Mesaj"] = "İletişim talebiniz alınmıştır.En kısa zamanda tarafımızca dönüş sağlanacaktır.";
                return RedirectToAction("Iletisim", "Home");
            }
            else
            {
                ViewBag.Durum = "Bir sorun oluştu";
                return View();
            }
        }
        [Route("isbasvuru")]
        public IActionResult IsBasvuru()
        {
            Ayarlar();
            return View();
        }

        [HttpPost]
        public IActionResult IsBasvuru(IsBasvuru model)
        {
            Ayarlar();
            bool eklendimi = bs.IsBasvuru_Ekle(model);
            if (eklendimi == true)
            {
                TempData["Mesaj"] = "Başvuru Talebiniz Alınmıştır En Kısa Sürede Dönüş Yapılacaktır.";
                return RedirectToAction("ISBasvuru", "Home");
            }
            else
            {
                ViewBag.Durum = "Bir sorun oluştu";
                return View();
            }
        }     
    }
}
