using AutoMapper;
using eshop.CouponAPI.Data.ValueObject;
using eShop.CouponAPI.Model;

namespace eShop.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }

    }
}
