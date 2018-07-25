using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentABike.Models;

namespace RentABike.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

       
        //[Min18years_Membership]
        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscibedToNewsLetter { get; set; }

       public byte MembershipTypeId { get; set; }
    }
}