using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sayt3.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace sayt3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        KitablarContext db = new KitablarContext();

        public IActionResult Index()
        {
            ViewBag.Kitab = db.Kitabs.Include(x => x.KitabJanr).Include(y => y.KitabYazici).ToList();
            ViewBag.Yazici = db.Yazicis.ToList();
            ViewBag.Janr = db.Janrs.ToList();
            return View();
        }
        public IActionResult KitabEtrafli(int id)
        {
            ViewBag.Kitab = db.Kitabs.Include(x => x.KitabJanr).Include(y => y.KitabYazici).SingleOrDefault(x =>x.KitabId==id);
            int a = ViewBag.Kitab.KitabJanrId;
            ViewBag.Janr = db.Janrs.ToList();

            ViewBag.Other = db.Kitabs.Where(x => x.KitabId !=id && x.KitabJanrId ==a).Take(3).ToList();
            return View();
        }
        public IActionResult Favorite(int id)
        {
            //ViewBag.Kitab = db.Kitabs.Include(x => x.KitabJanr).Include(y => y.KitabYazici).SingleOrDefault(x =>x.KitabId==id);
            ViewBag.FavBook = db.Favorites.Include(y => y.FavoriteKitab)./*Include(x => x.Kitab.KitabYazici).*/Where(x => x.FavoriteUserId == Convert.ToInt32(User.FindFirst(ClaimTypes.Sid).Value)).ToList();

            return View();
        }
        public IActionResult NewFavorite(int id)
        {
            Favorite f = new Favorite();
            f.FavoriteUserId = Convert.ToInt32( User.FindFirst(ClaimTypes.Sid).Value);
            f.FavoriteKitabId = id;
            db.Favorites.Add(f);
            db.SaveChanges();
            return  Json(f);
        }

        public IActionResult elave()
        {
            return View();
        }





    }

}
