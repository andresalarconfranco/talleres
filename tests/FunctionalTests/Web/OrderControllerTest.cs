using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Javeriana.Pica.FunctionalTests.Web
{
    public class OrderControllerTest : IClassFixture<WebTestFixture>
    {
        private const string AnnonymousId = "annonymous";

        private const string UnkownId = "does-not-exist";
        public OrderControllerTest(WebTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Theory]
        [InlineData(1, AnnonymousId)]
        public async Task Returns200OnOrderCreation(int basketId, string userId)
        {
            var getResponse = await Client.GetAsync("api/basket/user/" + userId);
            getResponse.EnsureSuccessStatusCode();
            var getStringResponse = await getResponse.Content.ReadAsStringAsync();
            var basket = JsonConvert.DeserializeObject<Basket>(getStringResponse);

            CatalogItem item = new CatalogItem(1, 2, "Pica T-Shirt", "T-Shirt", 20000, "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg");
            string postJson = JsonConvert.SerializeObject(item);
            var postRequestPayload = new StringContent(postJson, System.Text.Encoding.UTF8, "application/json");
            var postResponse = await Client.PostAsync("api/basket/" + basket.Id + "/items", postRequestPayload);
            postResponse.EnsureSuccessStatusCode();

            OrderModel orderModel = new OrderModel
            {
                BasketId = basketId,
                ShippingAddres = new Address("fake street 123","Bogota","Cundinamarca","Colombia","111111")
            };
            
            string json = JsonConvert.SerializeObject(orderModel);
            var requestPayload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/order", requestPayload);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Order>(stringResponse);

            Assert.Equal(userId, model.BuyerId);
        }

        [Theory]
        [InlineData(100, UnkownId)]
        public async Task Returns404OnOrderCreation(int basketId, string userId)
        {
            OrderModel orderModel = new OrderModel
            {
                BasketId = basketId,
                ShippingAddres = new Address("fake street 123", "Bogota", "Cundinamarca", "Colombia", "111111")
            };

            string json = JsonConvert.SerializeObject(orderModel);
            var requestPayload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/order", requestPayload);
            var statusCode = response.StatusCode;

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }
    }
}
