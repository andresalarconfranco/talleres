using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Javeriana.Pica.Infrastructure.Data
{
    public class BasketRepository : IRepository<Basket>
    {
        //TODO implementat todos los métodos de éste repositorio
        /// <summary>
        /// ESte repositorio simula una fuente de datos que mantiene la información
        /// de las canastas creadas en el sistema.
        /// Se cuenta con una lista de canastas que por defecto inicializa una
        /// a ombre de un usuario anónimo.
        /// </summary>
        private const string BuyerId = "annonymous";

        private const string BuyerIdJhon = "jhon";

        private IList<Basket> _basketList;

        private Basket _annonymousBasket;

        public BasketRepository()
        {
            _annonymousBasket = new Basket(BuyerId);
            _annonymousBasket.Id = 1;
            _annonymousBasket.AddItem(1, 1000, 1);
            _annonymousBasket.AddItem(1, 2000, 1);

            _basketList = new List<Basket>{ _annonymousBasket };

            _annonymousBasket = new Basket(BuyerIdJhon);
            _annonymousBasket.Id = 2;
            _annonymousBasket.AddItem(1, 1000, 1);
            _annonymousBasket.AddItem(1, 2000, 1);
            _annonymousBasket.AddItem(1, 3000, 1);

            _basketList.Add(_annonymousBasket);
        }

        public Basket Add(Basket entity)
        {
            _basketList.Add(entity);

            return GetById(entity.Id);
        }

        public Basket Delete(Basket entity)
        {
            _basketList.Remove(entity);

            return entity;
        }

        public Basket GetById(int id)
        {
            return _basketList.FirstOrDefault(x => x.Id == id);
        }

        public IList<Basket> ListAll()
        {
            return _basketList;
        }

        public Basket Update(Basket entity)
        {
            _basketList.ToList().ForEach(x => 
            {
                if (x.Id == entity.Id)
                {
                    x = entity;
                }
            });

            return _basketList.FirstOrDefault(x => x.Id == entity.Id);
        }
    }
}
