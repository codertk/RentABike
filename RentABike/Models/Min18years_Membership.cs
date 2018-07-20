using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace RentABike.Models
{
    public class Min18years_Membership:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var CustomerValidation = (Customer) validationContext.ObjectInstance;

            if (CustomerValidation.MembershipTypeId == 0 || CustomerValidation.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if (CustomerValidation.DateOfBirth == null)
            {
                return new ValidationResult("Birth Date Required");
            }

            var age = DateTime.Today.Year - CustomerValidation.DateOfBirth.Value.Year;

            if (age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
               return new ValidationResult("Age Should be 18 Years or More, otherwise Choose 'Pay As You Go'- Member type");
            }
        }
    }
}