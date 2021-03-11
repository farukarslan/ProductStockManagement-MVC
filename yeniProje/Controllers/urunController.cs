using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yeniProje.Models;
namespace yeniProje.Controllers
{
    public class urunController : Controller
    {
        // GET: urun
        public ActionResult Index()
        {
            return View();
        }
        urunCONTEXT db = new urunCONTEXT();
        public ActionResult urungir()
        {

            return View();
        }
        [HttpPost]
        public ActionResult urungir(urun yeniurun)
        {

            if (ModelState.IsValid == true)
            {
                db.urunler.Add(yeniurun);
                db.SaveChanges();
                ViewBag.mesaj = "Ürün kaydınız başarılı";
            }

            return View();
        }
        public ActionResult listele()
        {
            var veri = db.urunler.ToList();
            return View(veri);
        }
        public ActionResult zam()
        {

            return View();
        }
        [HttpPost]
        public ActionResult zam(double zamorani)
        {
            double artist = 1 + (zamorani / 100);
            var vericek = db.urunler.ToList();

            foreach (var item in vericek)
            {
                var zamlanacak = db.urunler.Find(item.id);
                zamlanacak.fiyati = zamlanacak.fiyati * artist;
                db.SaveChanges();
            }

            return RedirectToAction("listele");


        }
        public ActionResult indirimyap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult indirimyap(double indirimorani, double indirimlimiti)
        {
            double azalis = 1 - (indirimorani / 100);
            var vericek = db.urunler.ToList();

            foreach (var item in vericek)
            {
                if (item.fiyati < indirimlimiti)
                {
                    var zamlanacak = db.urunler.Find(item.id);
                    zamlanacak.fiyati = zamlanacak.fiyati * azalis;
                    db.SaveChanges();

                }
                else
                {
                    return RedirectToAction("listele");
                }

            }
            return RedirectToAction("listele");
        }

        public ActionResult seçim(int? id)
        {
            urun yeniurun = new urun();
            if (id == null)
            {
                yeniurun = db.urunler.Take(1).FirstOrDefault();

            }
            if (id == 1)
            {
                double maxveri = db.urunler.Max(i => i.fiyati);
                yeniurun = (from c in db.urunler
                            where c.fiyati == maxveri
                            select c).FirstOrDefault();
            }
            else if (id == 2)
            {
                double minveri = db.urunler.Min(i => i.fiyati);
                yeniurun = (from a in db.urunler
                            where a.fiyati == minveri
                            select a).FirstOrDefault();

            }
            else if (id == 3)
            {
                int eyau = db.urunler.Max(i => i.adet);
                yeniurun = (from e in db.urunler
                            where e.adet == eyau
                            select e).FirstOrDefault();
            }
            return View(yeniurun);
        }
        public ActionResult azalt(int id)
        {
            urun yeniurun = new urun();
            var gelenidbilgisininkodunubulmaseysi = db.urunler.Find(id);
            gelenidbilgisininkodunubulmaseysi.adet = gelenidbilgisininkodunubulmaseysi.adet + 1;
            db.SaveChanges();
            return RedirectToAction("listele");
        }
        public ActionResult arttir(int id)
        {
            urun yeniurun = new urun();
            var gelenidbilgisininkodunubulmaseysi = db.urunler.Find(id);
            gelenidbilgisininkodunubulmaseysi.adet = gelenidbilgisininkodunubulmaseysi.adet - 1;
            db.SaveChanges();
            return RedirectToAction("listele");
        }
        public ActionResult adetekle(int id, int degis)
        {
            var gelenidbilgisininkodunubulmaseysi = db.urunler.Find(id);
            gelenidbilgisininkodunubulmaseysi.adet = degis;
            db.SaveChanges();

            return RedirectToAction("listele");
        }
    }
}