using AddressBookAPI.Application.ViewModels;
using AddressBookAPI.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookAPI.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewAddressVm, Address>();
        }
    }
}
