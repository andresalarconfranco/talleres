using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.ApplicationCore.Services;
using Moq;
using System;
using Xunit;
using System.Threading.Tasks;
using Javeriana.Pica.ApplicationCore.Exceptions;

namespace Javeriana.Pica.UnitTests.Services
{
    public class SetQuantities
    {
        private readonly int _invalidId = -1;

        private readonly Mock<IRepository<Basket>> _mockBasketRepo;

        public SetQuantities()
        {
            _mockBasketRepo = new Mock<IRepository<Basket>>();
        }

        [Fact]
        public async Task ThrowsGivenInvalidBasketId()
        {
            var basketService = new BasketService(_mockBasketRepo.Object, null);

            await Assert.ThrowsAsync<BasketNotFoundException>(async () =>
                basketService.SetQuantities(_invalidId, new System.Collections.Generic.Dictionary<string, int>()));
        }

        [Fact]
        public async Task ThrowsGivenNullQuantities()
        {
            var basketService = new BasketService(null, null);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                basketService.SetQuantities(123, null));
        }

    }
}
