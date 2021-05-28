using AddressBook.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            this.CreateMap<Address, AddressModel>();
            this.CreateMap<AddressModel, Address>();
        }
    }
}
