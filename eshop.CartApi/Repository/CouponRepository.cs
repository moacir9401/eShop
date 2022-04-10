using AutoMapper;
using eshop.CartApi.Data.ValueObjects;
using eShop.CartAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eshop.CartApi.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _client;
        public const string basePath = "api/v1/coupon";

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CouponVO> GetCoupon(string couponCode, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ",""));

            var response = await _client.GetAsync($"api/v1/coupon/{couponCode}");

            var context = await response.Content.ReadAsStringAsync();

            if(response.StatusCode != HttpStatusCode.OK) return new CouponVO();

            return JsonSerializer.Deserialize<CouponVO>(context,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

        }
    }
}
