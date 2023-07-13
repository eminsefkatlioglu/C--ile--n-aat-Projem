using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sefkat.DataAccess;
using Sefkat.Entity;

namespace Sefkat.Business
{
    public class BaseController 
    {
        public KContext db;
        public BaseController()
        {
            db = new KContext();
        }
        
        public List<Slider> Slider_List()
        {
            return db.Sliderlar.ToList();
        }
        public bool Slider_Ekle(Slider model)
        {
            try
            {
                db.Sliderlar.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Slider Slider_Bul(int id)
        {
            return db.Sliderlar.FirstOrDefault(x => x.ID == id);
        }
        public bool Slider_Duzenle(Slider model)
        {
            try
            {
                var bul = Slider_Bul(model.ID);
                if (model.Icerik != null)
                {
                    bul.Icerik = model.Icerik;
                }

                if (model.Baslik != null)
                {
                    bul.Baslik = model.Baslik;
                }

                if (model.Resim != null)
                {
                    bul.Resim = model.Resim;
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                db.SaveChanges();
                return false;
            }
        }
        public bool Slider_Sil(int id)
        {
            try
            {
                var bul = Slider_Bul(id);
                db.Sliderlar.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public Blog Blog_Bul(int id)
        {
            return db.Bloglar.FirstOrDefault(x => x.ID == id);
        }

        public List<Blog> Blog_Listesi()
        {
            return db.Bloglar.ToList();
        }

        public bool Blog_Ekle(Blog model)
        {
            try
            {
                model.Tarih = DateTime.Now;
                db.Bloglar.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Blog_Duzenle(Blog model)
        {
            try
            {
                var bul = Blog_Bul(model.ID);
                bul.Baslik = model.Baslik;
                bul.Icerik = model.Icerik;
                bul.Resim = model.Resim;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Blog_Sil(int id)
        {
            try
            {
                var bul = Blog_Bul(id);
                db.Bloglar.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Iletisimcs> Iletisim_Listesi()
        {
            return db.Iletisimcs.ToList();
        }

        public Iletisimcs Iletisim_Bul(int id)
        {
            return db.Iletisimcs.FirstOrDefault(x => x.ID == id);
        }
        public bool Iletisim_Ekle(Iletisimcs model)
        {
            try
            {
                db.Iletisimcs.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<IsBasvuru> İsBasvuru_Listesi()
        {
            return db.IsBasvuru.ToList();
        }
       
        public bool İsBasvuru_Ekle(IsBasvuru model)
        {
            try
            {
                db.IsBasvuru.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Ev Ev_Bul(int id)
        {
            return db.Ev.FirstOrDefault(x => x.ID == id);
        }

        public List<Ev> Ev_Listele()
        {
            return db.Ev.ToList();
        }

        public bool Ev_Ekle(Ev model)
        {
            try
            {
                db.Ev.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Ev_Duzenle(Ev model)
        {
            try
            {
                var bul = Ev_Bul(model.ID);
                bul.Resim = model.Resim;
                bul.İl = model.İl;
                bul.İlce = model.İlce;
                bul.SatılıkKiralık = model.SatılıkKiralık;
                bul.Semt = model.Semt;
                bul.Mahalle = model.Mahalle;
                bul.Fiyat = model.Fiyat;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Ev_Sil(int id)
        {
            try
            {
                var bul = Ev_Bul(id);
                db.Ev.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Proje Proje_Bul(int id)
        {
            return db.Proje.FirstOrDefault(x => x.ID == id);
        }

        public List<Proje> Proje_Listele()
        {
            return db.Proje.ToList();
        }

        public bool Proje_Ekle(Proje model)
        {
            try
            {
                model.Resim = model.Resim;
                model.Baslik = model.Baslik;
                model.Icerik = model.Icerik;
                db.Proje.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Proje_Duzenle(Proje model)
        {
            try
            {
                var bul = Proje_Bul(model.ID);
                bul.Baslik = model.Baslik;
                bul.Icerik = model.Icerik;
                bul.Resim = model.Resim;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Proje_Sil(int id)
        {
            try
            {
                var bul = Proje_Bul(id);
                db.Proje.Remove(bul);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
