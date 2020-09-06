using Javeriana.Pica.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Javeriana.Pica.FunctionalTests.Web
{
    public class BaseControllerTest : IClassFixture<WebTestFixture>
    {
        protected const string AnnonymousId = "annonymous";

        protected const string NewUserId = "jhon";

        protected const string TargetUserId = "steve";

        protected readonly CatalogItem TShirtItem = new CatalogItem(1, 2, "Pica T-Shirt", "T-Shirt", 20000, "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg");

        protected readonly CatalogItem PantsItem = new CatalogItem(1, 2, "Pica Pants", "Pants", 80000, "https://cdn.shopify.com/s/files/1/0856/8732/products/www.imagehandler.net.png");

        protected readonly CatalogItem HoodieItem = new CatalogItem(1, 2, "Pica Hoodie", "Hoodie", 80000, "https://www.dressinn.com/f/13725/137255204/tommy-hilfiger-straight-logo-hoodie.jpg");

        protected HttpClient Client { get; }

        public BaseControllerTest(WebTestFixture factory)
        {
            Client = factory.CreateClient();
        }
    }
}
