using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Javeriana.Pica.Infrastructure.Data
{
    //TODO implemente todos los métodos de éste repositorio
    /// <summary>
    /// Este repositorio simula una fuente de datos que mantiene la información
    /// de las órdenes de compra creadas en el sistema.
    /// Se debe tener una lista de órdenes de compra, ver BasketRepository.cs
    /// </summary>
    public class OrderRepository : IRepository<Order>
    {
        private IList<Order> _orderList;

        public OrderRepository()
        {
            _orderList = new List<Order>
            {
                new Order("annonymous",
                        new Address("fake street 123","Bogota","Cundinamarca","Colombia","111111"),
                        new List<OrderItem>
                        {
                            new OrderItem(new CatalogItemOrdered(1,"Producto1", "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg"),1000,1),
                            new OrderItem(new CatalogItemOrdered(2,"Producto2", "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg"),2000,1)
                        })
            };
        }

        public Order Add(Order entity)
        {
            _orderList.Add(entity);

            return this.GetById(entity.Id);
        }

        public Order Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            return _orderList.FirstOrDefault(x => x.Id == id);
        }

        public IList<Order> ListAll()
        {
            return _orderList;
        }

        public Order Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
