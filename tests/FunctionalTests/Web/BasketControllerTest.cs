using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Javeriana.Pica.FunctionalTests.Web
{
    public class GetBasketControllerTest : BaseControllerTest
    {


        public GetBasketControllerTest(WebTestFixture factory) : base(factory)
        { }

        [Fact]
        public async Task ReturnsEmptyBasketSetup()
        {
            var response = await Client.GetAsync("api/basket");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<IEnumerable<Basket>>(stringResponse);

            Assert.True(1 == model.Count());
        }

        [Theory]
        [InlineData(AnnonymousId)]
        [InlineData(NewUserId)]
        public async Task ReturnsUserBasket(string userId)
        {
            var response = await Client.GetAsync("api/basket/user/" + userId);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Basket>(stringResponse);

            Assert.Equal(userId, model.BuyerId);
        }

    }

    public class PostBasketControllerTest : BaseControllerTest
    {
        public PostBasketControllerTest(WebTestFixture factory) : base(factory)
        { }

        [Theory]
        [InlineData(1, AnnonymousId)]
        [InlineData(2, NewUserId)]
        public async Task ReturnsUpdatedBasketAfterAddingItems(int basketId, string userId)
        {
            var getResponse = await Client.GetAsync("api/basket/user/" + userId);
            getResponse.EnsureSuccessStatusCode();

            CatalogItem item = new CatalogItem(1, 2, "Pica T-Shirt", "T-Shirt", 20000, "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg");
            string json = JsonConvert.SerializeObject(item);
            var requestPayload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/basket/" + basketId + "/items", requestPayload);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Basket>(stringResponse);

            Assert.Equal(userId, model.BuyerId);
        }
    }

    public class PutBasketControllerTest : BaseControllerTest
    {
        public PutBasketControllerTest(WebTestFixture factory) : base(factory)
        { }

        [Theory]
        [InlineData(1, AnnonymousId)]
        [InlineData(2, NewUserId)]
        public async Task ReturnsUpdatedBasketAfterUpdatingQuantities(int basketId, string userId)
        {
            var getResponse = await Client.GetAsync("api/basket/user/" + userId);
            getResponse.EnsureSuccessStatusCode();

            IDictionary<string, int> quantities = new Dictionary<string, int>();
            quantities.Add(new KeyValuePair<string, int>("1", 4));
            QuantityModel quantityModel = new QuantityModel
            {
                BasketId = basketId,
                Quantities = quantities
            };

            IEnumerable<QuantityModel> request = new List<QuantityModel>
            { 
                quantityModel
            };

            string json = JsonConvert.SerializeObject(request);
            var requestPayload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await Client.PutAsync("api/basket/" + basketId + "/items", requestPayload);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Basket>(stringResponse);

            Assert.Equal(userId, model.BuyerId);
        }

        [Theory]
        [InlineData(1, AnnonymousId,TargetUserId)]
        public async Task ReturnspdatedBasketAfterTransferingBasket(int basketId, string sourceUserId,string targetUserId)
        {
            var getResponse = await Client.GetAsync("api/basket/user/" + sourceUserId);
            getResponse.EnsureSuccessStatusCode();

            var requestPayload = new StringContent("", System.Text.Encoding.UTF8, "application/json");
            var response = await Client.PutAsync("api/basket/" + basketId + "/user/" + targetUserId, requestPayload);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Basket>(stringResponse);

            Assert.Equal(targetUserId, model.BuyerId);
        }

        [Theory]
        [InlineData(AnnonymousId, 0)]
        [InlineData(NewUserId, 0)]
        public async Task ReturnsBasketItemCount(string userId, int expectedItemCount)
        {
            var getResponse = await Client.GetAsync("api/basket/user/" + userId);
            getResponse.EnsureSuccessStatusCode();
            var getStringResponse = await getResponse.Content.ReadAsStringAsync();
            var basket = JsonConvert.DeserializeObject<Basket>(getStringResponse);

            CatalogItem item = new CatalogItem(1, 2, "Pica T-Shirt", "T-Shirt", 20000, "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg");
            string json = JsonConvert.SerializeObject(item);
            var requestPayload = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var postResponse = await Client.PostAsync("api/basket/" + basket.Id + "/items", requestPayload);
            postResponse.EnsureSuccessStatusCode();

            var response = await Client.GetAsync("api/basket/user/" + userId + "/count");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var actualCount = Int32.Parse(stringResponse);

            Assert.NotEqual(expectedItemCount, actualCount);
        }

    }
    
    public class DeleteBasketControllerTest : IClassFixture<WebTestFixture>
    {
        public HttpClient Client { get; }
        public DeleteBasketControllerTest(WebTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Returns200OnDeleteBasket()
        {
            var responseGet = await Client.GetAsync("api/basket");
            responseGet.EnsureSuccessStatusCode();
            var stringResponse = await responseGet.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<IEnumerable<Basket>>(stringResponse);

            Basket basket = model.First();
            var responseDelete = await Client.DeleteAsync("api/basket/" + basket.Id);
            responseDelete.EnsureSuccessStatusCode();
        }
        
    }
}
