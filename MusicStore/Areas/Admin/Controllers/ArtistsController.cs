using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MusicStore.Areas.Admin.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicStoreDbContext context = new Data.MusicStoreDbContext();
        // GET: Admin/Artists
        public ActionResult Index()
        {
            return View(context.Artists);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist model)
        {
            if (model.PhotoFile != null)
            {
                model.Photo = new WebImage(model.PhotoFile.InputStream).Resize(301, 301).Crop(1,1).AddTextWatermark("MusicStore", opacity: 70).GetBytes("jpeg");
            }

            context.Entry(model).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
            TempData["success"] = "Sanatçı ekleme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = context.Artists.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Artist model)
        {
            if (model.PhotoFile != null)
            {
                model.Photo = new WebImage(model.PhotoFile.InputStream).Resize(301, 301).Crop(1, 1).AddTextWatermark("MusicStore", opacity: 70).GetBytes("jpeg");
            }

            context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            TempData["success"] = "Sanatçı güncelleme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var model = context.Artists.Find(id);
            context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            TempData["success"] = "Sanatçı silme işlemi başarıyla tamamlanmıştır.";
            return RedirectToAction("Index");
        }
    }
}