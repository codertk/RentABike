using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentABike.Models;

namespace RentABike.Controllers
{
    public class BikesController : Controller
    {
        //
        // GET: /Bikes/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Bikes/Random
        public ActionResult Random()
        {
            var bike = new Bike() {Name = "ThunderBird 350"};
            return View(bike);
            //return Content("Hello World");
            //return HttpNotFound();
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }
	}
}