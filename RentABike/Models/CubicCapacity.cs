using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentABike.Models
{
    public class CubicCapacity
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string CC { get; set; }
    }
}