using System.Web.Mvc;
using TestData.Web.Models;
using TestData.Web.Services;

namespace TestData.Web.Controllers
{
    public class HomeController : Controller
    {
        DbData db;

        public HomeController(DbData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ExistingRestaurants()
        {
            var existing = db.Restaurants;

            return Json(existing, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddRestaurant(string Name, string Description)
        {
            var restaurant = new Restaurant();

            restaurant.Name = Name;
            restaurant.Description = Description;

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return Json(restaurant, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var restaurant = db.Restaurants.Find(Id);

            var model = restaurant;

            return View(model);

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {

            db.Update(restaurant);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var model = db.Get(Id);

            return View(model);
        }

        //FormCollection is passed only to make syntax valid
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection form)
        {

            db.Delete(Id);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    };
}