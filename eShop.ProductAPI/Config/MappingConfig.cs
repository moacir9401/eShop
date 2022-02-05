using AutoMapper;
using eShop.ProductAPIs.Data.ValueObjects;
using eShop.ProductAPIs.Model;

namespace eShop.ProductAPIs.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }

    }
}
