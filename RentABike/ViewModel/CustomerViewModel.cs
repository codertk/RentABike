using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentABike.Models;

namespace RentABike.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customers { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //public string PageTitle { get; set; }

        public string PageTitle
        {
            get
            {
                if(Customers != null && Customers.Id != 0)
                return "Edit Customer";
                else
                return "New Customer";
            }
        }




        /*
           *public string title
         * {
         * get
         * {
         * return Id!=0 ? "Edit":"New";
         * }
         * }  
         */
    }
}