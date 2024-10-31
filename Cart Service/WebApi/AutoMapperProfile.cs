using AutoMapper;
using OnlineShopping.CartService.WebApi.DAL.Entities;
using OnlineShopping.CartService.WebApi.UI.Controllers.Dtos;

namespace OnlineShopping.CartService.WebApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CartItem, CartItemDto>();
        CreateMap<AddCartItemDto, CartItem>()
            .ForMember(x => x.Id, options => options.Ignore());
    }
}
