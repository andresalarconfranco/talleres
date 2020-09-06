using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javeriana.Pica.Web.Models
{
    //TODO todos los atributos debe ser validado cómo requerido usando Model Validation
    public class QuantityModel
    {
        private int basketId;

        /// <summary>
        /// La llave de tipo string representa al Id del item,
        /// el valor de tipo int representa la cantidad
        /// </summary>
        private IDictionary<string, int> quantities;

        public IDictionary<string, int> Quantities { get => quantities; set => quantities = value; }
        public int BasketId { get => basketId; set => basketId = value; }

        public QuantityModel() { }
    }
}
