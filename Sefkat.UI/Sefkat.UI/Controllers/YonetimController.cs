using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sefkat.Entity;

namespace Sefkat.UI.Controllers
{
    [Authorize]
    public class YonetimController : BaseController
    {
        public IActionResult Anasayfa()
        {
            return View();
        }
        [Route("profil-sayfasi")]
        public IActionResult ProfilSayfasi()
        {
            return View();
        }
        [Route("mesajlar")]
        public IActionResult Mesajlar()
        {
            return View();
        }
        [Route("slider-listele")]
        public IActionResult SliderListele()
        {

            return View(Slider_List());
        }
        [Route("slider-ekle")]
        public IActionResult SliderEkle()
        {
            return View();
        }

        [HttpPost]
        [Route("slider-ekle/{id}")]
        public IActionResult SliderEkle(Slider model)
        {
            bool kontrol = Slider_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("SliderListele");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }
        [Route("slider-duzenle/{id}")]
        public IActionResult SliderDuzenle(int id)
        {
            return View(Slider_Bul(id));
        }
        [HttpPost]
        [Route("slider-duzenle/{id}")]
        public IActionResult SliderDuzenle(Slider model)
        {
            var kontrol = Slider_Duzenle(model);
            if (kontrol == true)
            {
                return RedirectToAction("SliderListele");
            }
            else
            {
                ViewBag.Durum = "Veritabansal Bir Hata Oluştu";
                return View();
            }
        }
        [Route("slider-sil/{id}")]
        public IActionResult SliderSil(int id)
        {
            var kontrol = Slider_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("SliderListele");
            }
            else
            {
                TempData["Durum"] = "Slider Silinemedi!";
                return RedirectToAction("SliderListele");
            }
        }

        [Route("blog")]
        public IActionResult Bloglar()
        {
            return View(Blog_Listesi());
        }

        [Route("blog-ekle")]
        public IActionResult BlogEkle()
        {
            return View();
        }

       

        [HttpPost]
        [Route("blog-ekle/{id}")]
        public IActionResult BlogEkle(Blog model)
        {
            var kontrol = Blog_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("Bloglar");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }
        [Route("blog-duzenle/{id}")]
        public IActionResult BlogDuzenle(int id)
        {
            return View(Blog_Bul(id));
        }

        [HttpPost]
        [Route("blog-duzenle")]
        public IActionResult BlogDuzenle(Blog model)
        {
            var kontrol = Blog_Duzenle(model);
            if (kontrol == true)
            {
                return RedirectToAction("Bloglar");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }
        [Route("blog-sil/{id}")]
        public IActionResult BlogSil(int id)
        {
            var kontrol = Blog_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("Bloglar");
            }
            else
            {
                TempData["Durum"] = "Veritabansal bir hata oluştu";
                return RedirectToAction("Bloglar");
            }
        }
        [Route("iletisimler")]
        public IActionResult Iletisim()
        {
            return View(Iletisim_Listesi());
        } [Route("iletisimler")]
        public IActionResult Iletim()
        {
            return View(Iletim_Listesi());
        }

        [Route("is-basvuru")]
        public IActionResult IsBasvuru()
        {
            return View(IsBasvuru_Listele());
        }
        [Route("hakkimizda-duzenle")]
        public IActionResult HakkimizdaDuzenle()
        {
            return View(db.Ayarlar.FirstOrDefault());
        }

        [HttpPost]
        [Route("hakkimizda-duzenle/{id}")]
        public IActionResult HakkimizdaDuzenle(Ayarlar model)
        {
            try
            {
                var bul = db.Ayarlar.FirstOrDefault();
                bul.Hakkimizda = model.Hakkimizda;
                db.SaveChanges();
                ViewBag.Durum = "1";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Durum = "2";
                return View();
            }
        }
        [Route("proje-liste")]
        public IActionResult Proje()
        {
            return View(Proje_Listele());
        }
        [Route("proje-ekle")]
        public IActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        [Route("proje-ekle/{id}")]
        public IActionResult ProjeEkle(Proje model)
        {
            var kontrol = Proje_Ekle(model);
            if (kontrol == true)
            {
                return RedirectToAction("Proje");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }
        [Route("proje-duzenle/{id}")]
        public IActionResult ProjeDuzenle(int id)
        {
            return View(Proje_Bul(id));
        }

        [HttpPost]
        [Route("proje-duzenle/{id}")]
        public IActionResult ProjeDuzenle(Proje model)
        {
            var kontrol = Proje_Duzenle(model);
            if (kontrol == true)
            {
                return RedirectToAction("Proje");
            }
            else
            {
                ViewBag.Durum = "Veritabansal bir hata oluştu";
                return View();
            }
        }
        [Route("proje-sil/{id}")]
        public IActionResult ProjeSil(int id)
        {
            var kontrol = Proje_Sil(id);
            if (kontrol == true)
            {
                return RedirectToAction("Proje");
            }
            else
            {
                TempData["Durum"] = "Veritabansal bir hata oluştu";
                return RedirectToAction("Proje");
            }
        }
    }
}
