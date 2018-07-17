using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace RentABike.Models
{
    public class Bike
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Model { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int NumberOfBikes { get; set; }

        public CubicCapacity CubicCapacity { get; set; }

        public int CubicCapacityId { get; set; }
    }
}