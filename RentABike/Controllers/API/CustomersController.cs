using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using RentABike.DTOs;
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
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        // GET
        // API/Customers
        [HttpGet]
        public CustomerDTO GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer,CustomerDTO>(customer);
        }

        //POST
        // API/Customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        //PUT
        //API/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
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

            Mapper.Map(customerDto, CustomerInDB);

            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (CustomerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(CustomerInDB);
            _context.SaveChanges();
        }



    }
}
