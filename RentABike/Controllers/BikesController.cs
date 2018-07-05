using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using RentABike.Models;
using RentABike.ViewModel;

namespace RentABike.Controllers
{
    public class BikesController : Controller
    {
        //
        // GET: /Bikes/
        public ActionResult Index()
        {
            var bikes = GetBikes();
            return View(bikes);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return new List<Bike>
            {
                new Bike{Id =1,Name = "ThunderBird 350"},
                new Bike{ Id = 2,Name = "Bajaj Pulsar RS200 "},
                new Bike{Id=3,Name = "Royal Enfield Classic 350 "},
                new Bike{Id=4,Name = "Honda Activa"}
            };
        }



        public ActionResult Details(int BikeId)
        {
            var bike = GetBikes().SingleOrDefault(c => c.Id == BikeId);
            return View(bike);
        }


        // GET: /Bikes/Random
        public ActionResult Random()
        {
            var bikes = new Bike() { Name = "ThunderBird 350" };

            var customers = new List<Customer>
            {
                new Customer{Name = "ThilaK"},
                new Customer{Name = "Kiruba"}

            };


            var ViewModel = new RandomMovieViewModel
            {
                Bikes = bikes,
                Customers = customers
            };

            return View(ViewModel);
            //return Content("Hello World");
            //return HttpNotFound();
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }
    }
}