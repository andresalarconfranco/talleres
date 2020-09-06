using Javeriana.Pica.ApplicationCore.Entities;
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
    public class CatalogControllerTest : IClassFixture<WebTestFixture>
    {
        public CatalogControllerTest(WebTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsFirst3CatalogItems()
        {
            var response = await Client.GetAsync("api/catalog");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<IEnumerable<CatalogItem>>(stringResponse);

            Assert.Equal(3, model.Count<CatalogItem>());
        }
    }
}
