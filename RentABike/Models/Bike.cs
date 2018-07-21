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
        
        [Required]
        public DateTime Model { get; set; }

        [Display(Name = "Date Of Purchase")]
        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Number Of Bikes")]
        [Required]
        [Range(1,10)]
        public int NumberOfBikes { get; set; }

        public CubicCapacity CubicCapacity { get; set; }
        
        [Display(Name = "Bike CC")]
        [Required]
        public int CubicCapacityId { get; set; }
    }
}