using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MusicStore.Areas.Admin.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicStoreDbContext context = new MusicStoreDbContext();
        // GET: Admin/Albums
        public ActionResult Index()
        {
            return View(context.Albums);
        }
        public ActionResult Create()
        {
            ViewBag.Genres = new SelectList(context.Genres.OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Artists = new SelectList(context.Artists.OrderBy(p => p.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album model)
        {
            if (model.PhotoFile != null)
            {
                model.CoverImage = new WebImage(model.PhotoFile.InputStream).Resize(601, 601).Crop(1, 1).AddTextWatermark("MusicStore", fontColor: "Red", opacity: 70).GetBytes("jpeg");
            }
            model.Price = decimal.Parse(model.PriceText);
            context.Entry(model).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
            TempData["success"] = "Album ekleme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(context.Genres.OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Artists = new SelectList(context.Artists.OrderBy(p => p.Name), "Id", "Name");
            var model = context.Albums.Find(id);
            model.PriceText = model.Price.ToString("n2");
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Album model)
        {
            if (model.PhotoFile != null)
            {
                model.CoverImage = new WebImage(model.PhotoFile.InputStream).Resize(601, 601).Crop(1, 1).AddTextWatermark("MusicStore", fontColor: "Red", opacity: 70).GetBytes("jpeg");
            }
            model.Price = decimal.Parse(model.PriceText);
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            TempData["success"] = "Album  güncelleme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var model = context.Albums.Find(id);
            context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            TempData["success"] = "Album silme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }

        public ActionResult Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return RedirectToAction("Index");

            var keywords = Regex.Split(keyword, @"\s+");
            var result = context.Albums.Where(p => keywords.Any(q => p.Name.Contains(q))).ToList();
            return View("Index", result);
        }
    }
} 