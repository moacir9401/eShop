using eShop.Models;

namespace eShop.Services.Iservices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProduct();
        Task<ProductModel> FindProductByID(long id);
        Task<ProductModel> CreateProduct(ProductModel model);
        Task<ProductModel> UpdateProduct(ProductModel model);
        Task<bool> DeleteProductById(long id);
    }
}
