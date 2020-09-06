using Javeriana.Pica.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Javeriana.Pica.ApplicationCore.Interfaces
{
    /// <summary>
    /// Este servicio debe administrar una coleccion de objetos tipo Basket:
    /// 
    /// - Cada Basket puede tener un usuario asociado, si no lo tiene entonces se considera cómo anónimo
    /// - Cada Basket maneja una colección de elementos
    /// - Se puede añadir items a un basket determinado
    /// - Se puede eliminar un Basket a partir de su Id
    /// - Se puede transferir una Basket de un usuario a otro
    /// - Se puede actualizar las cantidades de los items añadidos previamente al Basket
    /// </summary>
    public interface IBasketService
    {
        /// <summary>
        /// Obtiene la canitdad de items añadidos al Basket de un usuario determinado
        /// </summary>
        /// <param name="userName">Usuario al que pertenece el Basket</param>
        /// <returns>Número de items en el Basket</returns>
        public int GetBasketItemCount(string userName);

        /// <summary>
        /// Transfiere la titularidad del Basket de un usuario de origen a un usaurio destino
        /// sin alterar el contenido del Basket
        /// </summary>
        /// <param name="anonymousId">Usuario de origen</param>
        /// <param name="userName">Usuario destino</param>
        /// <returns>El Basket actualizado</returns>
        public Basket TransferBasket(string anonymousId, string userName);

        /// <summary>
        /// Añade un nuevo item del catalogo a un Basket determinado
        /// </summary>
        /// <param name="basketId">Basket a modificar</param>
        /// <param name="catalogItemId">Item del catálogo a añadir</param>
        /// <param name="price">Precio del item</param>
        /// <param name="quantity">Cantidad del item</param>
        /// <returns>El Basket actualizado</returns>
        public Basket AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity = 1);

        /// <summary>
        /// Actualiza las cantidades de los items existentes en un Basket determinado
        /// </summary>
        /// <param name="basketId">Identificador del Basket</param>
        /// <param name="quantities">Colección de items a modificar y sus cantidades</param>
        /// <returns>El Basket actualizado</returns>
        public Basket SetQuantities(int basketId, Dictionary<string, int> quantities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId">Basket a eliminar</param>
        /// <returns>El Basket actualizado y vacío (sin elementos y con totales en cero)</returns>
        public Basket DeleteBasket(int basketId);

        /// <summary>
        /// Obtiene todas los basket
        /// </summary>
        /// <returns></returns>
        public IList<Basket> GetAllBasket();

        public Basket GetBasketByUserName(string userName);

        public Basket BasketById(int id);
    }
}
