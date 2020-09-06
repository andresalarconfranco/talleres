using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.ApplicationCore.Services;
using Javeriana.Pica.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderModel orderModel)
        {
            try
            {
                var resultado = this._orderService.CreateOrder(orderModel.BasketId, orderModel.ShippingAddres);

                if (resultado != null)
                {
                    return Ok(resultado);
                }
                else
                {
                    return NotFound(new Order());
                }

            }
            catch (Exception ex)
            {
                return NotFound(new Order());
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
