using AutoMapper;
using MovieApi.Data.Dtos.AddressDtos;
using MovieApi.Models;

namespace MovieApi.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
