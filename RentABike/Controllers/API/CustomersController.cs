using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using RentABike.Models;
using RentABike.ViewModel;

namespace RentABike.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        // GET
        // API/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET
        // API/Customers

        public Customer GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        //POST
        // API/Customers

        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT
        //API/Customers/1

        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var CustomerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (CustomerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            CustomerInDB.Name = customer.Name;
            CustomerInDB.DateOfBirth = customer.DateOfBirth;
            CustomerInDB.IsSubscibedToNewsLetter = customer.IsSubscibedToNewsLetter;
            CustomerInDB.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }

    }
}
