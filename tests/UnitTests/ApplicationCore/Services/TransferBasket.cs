using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.ApplicationCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Javeriana.Pica.UnitTests.Services
{
    public class TransferBasket
    {
        private readonly string _buyer_source = "steve";
        private readonly string _buyer_target = "thomas";

        private readonly Mock<IRepository<Basket>> _mockBasketRepo;

        public TransferBasket()
        {
            _mockBasketRepo = new Mock<IRepository<Basket>>();
        }

        [Fact]
        public async Task ThrowsGivenNullAnonymousId()
        {
            var basketService = new BasketService(null, null);

            Assert.Throws<ArgumentNullException>(() => basketService.TransferBasket(null, _buyer_target));
        }

        [Fact]
        public async Task ThrowsGivenNullUserId()
        {
            var basketService = new BasketService(null, null);

            Assert.Throws<ArgumentNullException>( () =>  basketService.TransferBasket("abcdefg", null));
        }

        [Fact]
        public async Task TansferBasket()
        {
            var basketService = new BasketService(_mockBasketRepo.Object, null);
            
            var basket1 = new Basket(_buyer_source);
            basket1.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            basket1.AddItem(2, It.IsAny<decimal>(), It.IsAny<int>());
            
            var basket2 = new Basket("abcd");
            basket2.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            basket2.AddItem(2, It.IsAny<decimal>(), It.IsAny<int>());

            var baskets = new List<Basket> { basket1, basket2 };

            _mockBasketRepo.Setup(x => x.ListAll())
                .Returns(baskets);
            _mockBasketRepo.Setup(x => x.Update(basket1))
                .Returns(basket1);

            Assert.Equal(_buyer_target, basketService.TransferBasket(_buyer_source, _buyer_target).BuyerId);
        }
    }
}
