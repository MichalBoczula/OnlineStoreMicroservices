using Newtonsoft.Json;
using OnlineStoreMicroservices.ShoppingCart.Features.Queries.GetDiscountCoupons;
using OnlineStoreMicroservices.ShoppingCart.Models;
using OnlineStoreMicroservices.ShoppingCart.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreMicroservices.ShoppingCart.Service
{
    public class SynchNotificationService : ISynchNotificationService
    {
        private readonly HttpClient _httpClient;

        public SynchNotificationService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IEnumerable<DiscountCouponExternal>> CheckIfCouponExists()
        {
            var response = await _httpClient.GetAsync("https://localhost:44331/api/DiscountCoupon");
            var dataAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<DiscountCouponExternal>>(dataAsString);
            return result;
        }

        public async Task<bool> SetCouponAsUnActive(string integrationId)
        {
            var content = new StringContent(JsonConvert.SerializeObject(integrationId), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44331/api/DiscountCoupon/deactivate", content);
            var dataAsString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(dataAsString);
            return result;
        }
    }
}
