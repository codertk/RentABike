﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentABike.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18years_Membership]
        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscibedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Memebership Type")]
        public byte MembershipTypeId { get; set; }

    }
}