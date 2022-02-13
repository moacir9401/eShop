using eShop.Models;
using eShop.Services.Iservices;
using eShop.Utils;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eShop.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string basePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{basePath}/find-cart/{userId}");

            return await response.ReadContentAs<CartViewModel>();
        }
        public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{basePath}/add-cart", model);
            if(response.IsSuccessStatusCode)
            return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
        public async Task<CartViewModel> UpdateCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var response = await _client.PutAsJson($"{basePath}/update-cart", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
        public async Task<bool> removeFromCart(long cartId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{basePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
        public Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }


        public Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
