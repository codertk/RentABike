using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using RentABike.Models;
using RentABike.ViewModel;
using System.Data.Entity;

namespace RentABike.Controllers
{
    public class BikesController : Controller
    {

        public ApplicationDbContext _Context;

        public BikesController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        //
        // GET: /Bikes/
        public ActionResult Index()
        {
            var bikes = _Context.Bikes.Include(c => c.CubicCapacity).ToList();
            if (User.IsInRole(RoleName.CanManageBikes))
                return View("IndexAdmin", bikes);
            return View("IndexUser",bikes);
        }
        [Authorize(Roles = RoleName.CanManageBikes)]
        public ActionResult BikeForm()
        {
            var cubiccapsacity = _Context.CubicCapacities.ToList();
            var viewModel = new BikeViewModel
            {
                Bikes = new Bike(),
                CubicCapacities = cubiccapsacity
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBike(Bike Bikes)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BikeViewModel
                {
                    Bikes = Bikes,
                    CubicCapacities = _Context.CubicCapacities.ToList()
                };
                return View("BikeForm", viewModel);
            }
            if (Bikes.Id == 0)
            {
                _Context.Bikes.Add(Bikes);
            }
            else
            {
                var BikeInDB = _Context.Bikes.Single(b => b.Id == Bikes.Id);
                BikeInDB.Name = Bikes.Name;
                BikeInDB.Model = Bikes.Model;
                BikeInDB.CubicCapacityId = Bikes.CubicCapacityId;
                BikeInDB.DateOfPurchase = Bikes.DateOfPurchase;
                BikeInDB.NumberOfBikes = Bikes.NumberOfBikes;
            }
            _Context.SaveChanges();
            return RedirectToAction("Index", "Bikes");
        }

        public ActionResult Edit(int bikeid)
        {
            var BikeInfo = _Context.Bikes.SingleOrDefault(bike => bike.Id == bikeid);
            var BikeVM = new BikeViewModel
            {
                Bikes = BikeInfo,
                CubicCapacities = _Context.CubicCapacities.ToList()
            };
            return View("BikeForm", BikeVM);
        }

        public ActionResult Details(int BikeId)
        {
            var bike = _Context.Bikes.Include(c => c.CubicCapacity).SingleOrDefault(c => c.Id == BikeId);
            return View(bike);
        }


        /*
          
         * public IEnumerable<Bike> GetBikes()
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
       */


    }
}