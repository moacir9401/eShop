using eShop.Models;
using eShop.Services.Iservices;
using eShop.Utils;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eShop.Services
{
    public class CouponServices : ICouponServices
    {
        private readonly HttpClient _client;
        public const string basePath = "api/v1/coupon";

        public CouponServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CouponViewModel> GetCoupon(string code, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.GetAsync($"{basePath}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();
                return await response.ReadContentAs<CouponViewModel>();
        }


    }
}
