using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Areas.Admin.Controllers
{
    public class GenresController : Controller
    {
        private readonly MusicStoreDbContext context = new Data.MusicStoreDbContext();
        // GET: Admin/Genres
        public ActionResult Index()
        {
            return View(context.Genres);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre model)
        {
            context.Entry(model).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
            TempData["success"] = "Tür ekleme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = context.Genres.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Genre model)
        {
            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            TempData["success"] = "Tür güncelleme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var model = context.Genres.Find(id);
            context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            TempData["success"] = "Tür silme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }
    }
}