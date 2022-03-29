using AutoMapper;
using eshop.CartApi.Data.ValueObjects;
using eshop.CartApi.Model;
using eShop.CartAPI.Data.ValueObjects;
using eShop.CartAPI.Model;

namespace eShop.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartVO, Cart>().ReverseMap();
            });
            return mappingConfig;
        }

    }
}
