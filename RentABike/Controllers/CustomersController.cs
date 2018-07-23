using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using RentABike.Models;
using RentABike.ViewModel;

namespace RentABike.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var memberShipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                Customers = new Customer(),
                MembershipTypes = memberShipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer(Customer Customers)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customers = Customers,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };

                return View("CustomerForm", viewModel);
            }
            if (Customers.Id == 0)
            {
                _context.Customers.Add(Customers);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == Customers.Id);

                customerInDB.Name = Customers.Name;
                customerInDB.DateOfBirth = Customers.DateOfBirth;
                customerInDB.MembershipTypeId = Customers.MembershipTypeId;
                customerInDB.IsSubscibedToNewsLetter = Customers.IsSubscibedToNewsLetter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        //
        // GET: /Customers/
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }


        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            //Need to redirect to Customer Form, But it's using ViewModel

            var viewModel = new CustomerViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        /*
       private IEnumerable<Customer> GetCustomers()
       {
           return new List<Customer>
           {
               new Customer{Id = 1,Name = "Thilak"},
               new Customer{Id = 2,Name = "Kiruba"},
               new Customer{Id=3,Name = "TK"}

           };
       }
          
         */
    }
}