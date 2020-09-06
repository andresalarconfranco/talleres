
using Ardalis.GuardClauses;
using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Exceptions;
using Javeriana.Pica.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Javeriana.Pica.ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepository;

        private readonly IAppLogger<BasketService> _logger;

        public BasketService(IRepository<Basket> basketRepository, IAppLogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public int GetBasketItemCount(string userName)
        {
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            Basket basket = GetBasketByUserName(userName);
            if (basket == null)
            {
                _logger.LogInformation($"No basket found for {userName}");
                return 0;
            }
            int count = basket.Items.Sum(i => i.Quantity);
            _logger.LogInformation($"Basket for {userName} has {count} items.");
            return count;
        }

        public Basket TransferBasket(string anonymousId, string userName)
        {
            Guard.Against.NullOrEmpty(anonymousId, nameof(anonymousId));
            Guard.Against.NullOrEmpty(userName, nameof(userName));
            Basket basket = GetBasketByUserName(anonymousId);
            if (basket == null)
                throw new BasketNotFoundException(anonymousId);

            basket.SetNewBuyerId(userName);
            return _basketRepository.Update(basket);
        }

        public Basket AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity = 1)
        {
            var basket = _basketRepository.GetById(basketId);

            basket.AddItem(catalogItemId, price, quantity);

            return _basketRepository.Update(basket);
        }

        public Basket SetQuantities(int basketId, Dictionary<string, int> quantities)
        {
            Guard.Against.Null(quantities, nameof(quantities));
            var basket = _basketRepository.GetById(basketId);
            if (basket == null)
                throw new BasketNotFoundException(basketId);

            foreach (var item in basket.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    if (_logger != null) _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                    item.SetNewQuantity(quantity);
                }
            }
            basket.RemoveEmptyItems();
            return _basketRepository.Update(basket);
        }

        public Basket DeleteBasket(int basketId)
        {
            var basket = _basketRepository.GetById(basketId);
            return _basketRepository.Delete(basket);
        }

        public  Basket GetBasketByUserName(string userName)
        {
            var baskets = _basketRepository.ListAll();
            Basket basket = baskets.FirstOrDefault(basket => basket.BuyerId == userName);
            return basket;
        }

        public IList<Basket> GetAllBasket()
        {
            return _basketRepository.ListAll();
        }

        public Basket BasketById(int id)
        {
            return _basketRepository.GetById(id);
        }
    }
}