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

        [Display(Name = "Date Of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Number Of Bikes")]
        public int NumberOfBikes { get; set; }

        public CubicCapacity CubicCapacity { get; set; }
        [Display(Name = "Bike CC")]
        public int CubicCapacityId { get; set; }
    }
}