using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.ApplicationCore.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Javeriana.Pica.UnitTests.Services
{
    public class DeleteBasket
    {
        private readonly string _buyerId = "Test buyerId";

        private readonly Mock<IRepository<Basket>> _mockBasketRepo;

        public DeleteBasket()
        {
            _mockBasketRepo = new Mock<IRepository<Basket>>();
        }

        [Fact]
        public async Task Should_InvokeBasketDelete_Once()
        {
            var basket = new Basket(_buyerId);
            basket.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
            basket.AddItem(2, It.IsAny<decimal>(), It.IsAny<int>());
            _mockBasketRepo.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(basket);
            var basketService = new BasketService(_mockBasketRepo.Object, null);

            basketService.DeleteBasket(It.IsAny<int>());

            _mockBasketRepo.Verify(x => x.Delete(It.IsAny<Basket>()), Times.Once);
        }
    }
}
