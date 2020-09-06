
using Ardalis.GuardClauses;
using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Exceptions;
using Javeriana.Pica.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Javeriana.Pica.ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        private readonly IRepository<Basket> _basketRepository;

        private readonly IRepository<CatalogItem> _itemRepository;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<Basket> basketRepository,
            IRepository<CatalogItem> itemRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _itemRepository = itemRepository;
        }

        public Order CreateOrder(int basketId, Address shippingAddress)
        {
            var basket = _basketRepository.GetById(basketId);
            if (basket == null)
                throw new BasketNotFoundException(basketId);

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var catalogItem = _itemRepository.GetById(item.CatalogItemId);
                var itemOrdered = new CatalogItemOrdered(catalogItem.Id, catalogItem.Name, catalogItem.PictureUri);
                var orderItem = new OrderItem(itemOrdered, item.UnitPrice, item.Quantity);
                items.Add(orderItem);
            }
            var order = new Order(basket.BuyerId, shippingAddress, items);

            return _orderRepository.Add(order);
        }
    }
}