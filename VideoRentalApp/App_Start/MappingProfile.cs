using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VideoRentalApp.Dtos;
using VideoRentalApp.Migrations;
using VideoRentalApp.Models;
using VideoRentalAPP.Models;

namespace VideoRentalApp.App_Start
{
    public class MappingProfile : Profile       
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}