using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using KullanıcıHataları.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KullanıcıHataları.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var sonuc = _context.Hata.Where(x=>x.Status==true).ToList();
            return View(sonuc);
        }
        [HttpGet]
        public IActionResult YeniHata()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniHata(Hatalar hatalar)
        {
            if (String.IsNullOrEmpty(hatalar.HataBaslik))
            {
                return View(hatalar);
            }
            hatalar.Status = true;
            _context.Set<Hatalar>().Add(hatalar);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult HataDuzelt(int id)
        {
            var hatam = _context.Hata.FirstOrDefault(x => x.HataId == id && x.Status==true);
            if(hatam != null)
            {
                return View(hatam);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult HataDuzelt(Hatalar duzenlenmis)
        {
            var duzenlenecek = _context.Hata.FirstOrDefault(x => x.HataId == duzenlenmis.HataId & x.Status==true);
           
            if (duzenlenecek!=null)
            {
                duzenlenecek.HataBaslik = duzenlenmis.HataBaslik;
                duzenlenecek.HataCozum = duzenlenmis.HataCozum;
                duzenlenecek.HataBitti = duzenlenmis.HataBitti;
                duzenlenecek.Hataİcerik = duzenlenmis.Hataİcerik;

                _context.Set<Hatalar>().Update(duzenlenecek);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult HataSil(int id)
        {
            var hatasil = _context.Hata.FirstOrDefault(x => x.HataId == id);
            

            if (hatasil != null)
            {
                _context.Hata.Remove(hatasil);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var hata = _context.Hata.FirstOrDefault(x => x.HataId == id && x.Status == true);
            if (hata != null)
            {
                hata.Status = false;
                _context.Set<Hatalar>().Update(hata);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

     
            

        //public IActionResult HataSil(int hataId)
        //{
        //    var hatasil = _context.Hata.FirstOrDefault(n => n.HataId == hataId);
        //    if(hatasil != null)
        //    {
        //        _context.Hata.Remove(hatasil);
        //        _context.SaveChanges();
        //    }
        //}
        //[HttpDelete("delete-hata-by-id/{id}")]




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
