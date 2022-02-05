using eShop.Models;
using eShop.Services.Iservices;
using eShop.Utils;

namespace eShop.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/vi/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProduct()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContextAs<List<ProductModel>>();
        }
        public async Task<ProductModel> FindProductByID(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContextAs<ProductModel>();
        }
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson<ProductModel>(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContextAs<ProductModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }
        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson<ProductModel>(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContextAs<ProductModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }
        public async Task<bool> DeleteProductById(long id)
        {

            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContextAs<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }

    }
}
