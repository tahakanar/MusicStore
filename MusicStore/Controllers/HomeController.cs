using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStore.Data.MusicStoreDbContext context = new Data.MusicStoreDbContext();
        public ActionResult Index()
        {
            return View(context.Albums.Include("Genre").Include("Artist").OrderByDescending(p => p.Date).Take(12));
        }

        public ActionResult Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return RedirectToAction("Index");

            var keywords = Regex.Split(keyword, @"\s+");
            var result = context.Albums.Where(p => keywords.Any(q => p.Name.Contains(q)) || keywords.Any(q => p.Artist.Name.Contains(q)) || keywords.Any(q => p.Genre.Name.Contains(q))).ToList();
            return View(result);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Genre(int id)
        {
            return View(context.Genres.Find(id));
        }

        public ActionResult Artist(int id)
        {
            return View(context.Artists.Find(id));
        }

        public ActionResult ArtistList()
        {
            return View(context.Artists.Include("Albums").OrderBy(p=>p.Name));
        }

        public ActionResult Album(int id)
        {           
            var model = context.Albums.Find(id);

            var reviews = Session["reviews"] as List<int>;
            if(!reviews.Any(p=>p == id))
            {
                model.Reviews++;
                context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                reviews.Add(id);
            }

           return View(model);
        }

        public ActionResult CategoryMenu()
        {
            return View(context.Genres.OrderBy(p => p.Name));
        }

        public ActionResult TopReviews()
        {
            return View(context.Albums.OrderByDescending(p => p.Reviews).Take(5));
        }

        public ActionResult ShoppingChart() => View(Session["shoppingchart"]);

        public ActionResult Add2Chart (int id)
        {
            var album = context.Albums.Find(id);
            var chart = Session["shoppingchart"] as ShoppingChart;
            chart.Add(new ChartItem
            {
                AlbumId = id,
                Price = album.Price,
                Quantity = 1,
                Name = album.Name,
                CoverImage = album.CoverImage
            });
            TempData["success"] = $"{album.Name} isimli albüm sepetinize eklenmiştir.";
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult IncreaseChartItem(int id)
        {
            var chart = Session["shoppingchart"] as ShoppingChart;
            chart.Add(id);
            TempData["success"] = $"Sepetiniz güncellenmiştir.";

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DecreaseChartItem(int id)
        {
            var chart = Session["shoppingchart"] as ShoppingChart;
            chart.DecreaseQuantity(id);
            TempData["success"] = $"Sepetiniz güncellenmiştir.";

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult RemoveChartItem(int id)
        {
            var chart = Session["shoppingchart"] as ShoppingChart;
            chart.Remove(id);
            TempData["success"] = $"Sepetiniz güncellenmiştir.";

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ClearShoppingChart()
        {
            var chart = Session["shoppingchart"] as ShoppingChart;
            chart.Clear();
            TempData["success"] = $"Sepetiniz güncellenmiştir.";

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ShoppingChartButton()
        {
            return View(Session["shoppingchart"]);
        }
    }
}