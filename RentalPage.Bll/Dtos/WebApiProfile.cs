using AutoMapper;
using RentalPage.Dal.Models;

namespace RentalPage.Bll.Dtos
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RentItem, RentItemDto>().ReverseMap();
            CreateMap<RentedItem, RentedItemDto>().ReverseMap();
        }

    }
}
