using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using patrickLearn.DTOs.Husband;
using patrickLearn.DTOs.Wife;
using patrickLearn.Models;

namespace patrickLearn
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<Husband,GetHusbandDTO>();
             CreateMap<AddHusbandDTO,Husband>();
             CreateMap<UpdateHusbandDTO,Husband>();

             CreateMap<Wife,GetWifeDTO>();
        }
    }
}