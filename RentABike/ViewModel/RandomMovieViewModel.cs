using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentABike.Models;

namespace RentABike.ViewModel
{
    public class RandomMovieViewModel
    {
        public Bike Bikes { get; set; }
        public List<Customer> Customers { get; set; }
    }
}