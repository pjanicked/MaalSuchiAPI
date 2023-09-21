using AutoMapper;
using MaalSuchiAPI.DTO;
using MaalSuchiAPI.Models;

namespace MaalSuchiAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StoreItemDto, StoreItem>();
            CreateMap<VendorDto, Vendor>();
        }
    }
}
