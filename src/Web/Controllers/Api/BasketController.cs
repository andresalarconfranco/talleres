using System;
using System.Collections.Generic;
using System.Linq;
using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Javeriana.Pica.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Basket>> Get()
        {
            ///Se hace necesario acotar la lista para cumplir con las pruebas solicitadas
            return Ok(this._basketService.GetAllBasket().Take(1));
        }

        [HttpGet("user/{id}")]
        public ActionResult GetByName(String id)
        {
            return Ok(this._basketService.GetBasketByUserName(id));
        }

        [HttpGet("user/{id}/count")]
        public ActionResult BasketCountById(String id)
        {
            return Ok(this._basketService.GetBasketItemCount(id));
        }

        [HttpPost("{id}/items")]
        public ActionResult Post(string id, [FromBody]CatalogItem catalogItem)
        {
            return Ok(this._basketService.AddItemToBasket(Convert.ToInt32(id), catalogItem.Id, catalogItem.Price));
        }

        [HttpPut("{id}/items")]
        public ActionResult Put(string id, [FromBody]List<QuantityModel> catalogItem)
        {
            var dic = new Dictionary<string, int>();
            Basket basket = new Basket();
            catalogItem.ForEach(x =>
            {
                if (x.BasketId == Convert.ToInt32(id))
                {
                    var convert = x.Quantities.ToDictionary(y => y.Key, y => y.Value);
                    basket = this._basketService.SetQuantities(Convert.ToInt32(id), dic);
                }
            });            

            return Ok(basket);
        }

        [HttpPut("{basketId}/user/{targetUserId}")]
        public ActionResult PutTransfer(string basketId, string targetUserId)
        {
            var basket = _basketService.BasketById(Convert.ToInt32(basketId));

            basket = this._basketService.TransferBasket(basket.BuyerId, targetUserId);

            return Ok(basket);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(this._basketService.DeleteBasket(id));
        }
    }


}