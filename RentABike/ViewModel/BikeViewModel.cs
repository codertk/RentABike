using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentABike.Models;

namespace RentABike.ViewModel
{
    public class BikeViewModel
    {
        public IEnumerable<CubicCapacity> CubicCapacities { get; set; }

        public Bike Bikes { get; set; }

        public string PageTitle { get; set; }
    }
}