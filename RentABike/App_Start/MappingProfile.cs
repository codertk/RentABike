using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RentABike.DTOs;
using RentABike.Models;

namespace RentABike.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}