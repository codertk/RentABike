﻿using System;
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
                _context=new ApplicationDbContext();
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
                MembershipTypes = memberShipTypes
            };
            return View(viewModel);
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