
using Javeriana.Pica.ApplicationCore.Entities;

namespace Javeriana.Pica.ApplicationCore.Interfaces
{
    /// <summary>
    /// Este servicio debe administrar las órdenes de compra:
    /// 
    /// - Sólo se puede crear una orden de compra por cada canasta
    /// - La información de entrega es obligatoira
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Crea una órden de compra a partir de una canasta e información de entrega
        /// </summary>
        /// <param name="basketId">Canasta que se va a asociar a la órden de compra</param>
        /// <param name="shippingAddress">Información de entrega</param>
        /// <returns>La nueva orden de compra</returns>
        public Order CreateOrder(int basketId, Address shippingAddress);
    }
}
