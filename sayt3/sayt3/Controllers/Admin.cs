using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sayt3.Models;

namespace sayt3.Controllers
{
    [Authorize(Roles ="admin")]
    public class Admin : Controller

    {
        KitablarContext db=new KitablarContext();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Kitab()
        {
            ViewBag.Kitab = db.Kitabs.Include(x=>x.KitabJanr).Include(y=>y.KitabYazici).ToList();
            ViewBag.Yazici=db.Yazicis.ToList();
            ViewBag.Janr=db.Janrs.ToList();

            return View();
        }


        public IActionResult KitabElave()
        {
            ViewBag.yazici=db.Yazicis.ToList();
            ViewBag.janr = db.Janrs.ToList();


            return View();

        }

        [HttpPost]
        public IActionResult KitabElave(Kitab t , IFormFile KitabSekil)
        {
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(KitabSekil.FileName);

            using (Stream stream = new FileStream("wwwroot/img/" + fileName, FileMode.Create))
            {
                KitabSekil.CopyTo(stream);
            }

            t.KitabSekil = fileName;

            db.Kitabs.Add(t);
            db.SaveChanges();


            return RedirectToAction("Kitab");

        }

        public IActionResult KitabSil(int id)
        {
            var a=db.Kitabs.FirstOrDefault(x=>x.KitabId == id);
            db.Kitabs.Remove(a);
            db.SaveChanges();

            return RedirectToAction("Kitab");

        }

        public IActionResult KitabEdit(int id)
        {
            ViewBag.Kitab=db.Kitabs.SingleOrDefault(x=>x.KitabId==id);
            ViewBag.yazici = db.Yazicis.ToList();
            ViewBag.janr = db.Janrs.ToList();

            return View();

        }

        [HttpPost]
        public IActionResult KitabEdit(int id,Kitab t, IFormFile KitabSekil)

        {
            var b = db.Kitabs.SingleOrDefault(y => y.KitabId == id);
            if (KitabSekil != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(KitabSekil.FileName);

                using (Stream stream = new FileStream("wwwroot/img/" + fileName, FileMode.Create))
                {
                    KitabSekil.CopyTo(stream);
                }
                t.KitabSekil = fileName;
                b.KitabSekil = t.KitabSekil;
            }


         
            b.KitabAd = t.KitabAd;
            b.KitabMelumat = t.KitabMelumat;
            b.KitabQiymet = t.KitabQiymet;
            b.KitabYaziciId=t.KitabYaziciId;
            b.KitabJanrId=t.KitabJanrId;
          

            db.SaveChanges();

            return RedirectToAction("Kitab");

        }


    }
}
