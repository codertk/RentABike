using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentABike.Models;

namespace RentABike.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id = 1,Name = "Thilak"},
                new Customer{Id = 2,Name = "Kiruba"},
                new Customer{Id=3,Name = "TK"}

            };
        }

        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();
            
            return View(customer);
        }
	}
}