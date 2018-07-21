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
        public string PageTitle { get; set; }

        /*
         *public string title
         * {
         * get
         * {
         * If(movie!=null && movie.id!=0)
         * return "Edit Movie";
         * Else
         * return "New Movie";
                 */


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