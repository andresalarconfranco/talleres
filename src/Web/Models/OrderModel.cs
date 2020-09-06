using Javeriana.Pica.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Javeriana.Pica.Web.Models
{
    //TODO todos los atributos debe ser validado cómo requerido usando Model Validation
    public class OrderModel
    {
        private int basketId;
        
        private Address shippingAddres;

        [BindProperty]
        public Address ShippingAddres { get => shippingAddres; set => shippingAddres = value; }

        [BindProperty]
        public int BasketId { get => basketId; set => basketId = value; }
    }
}
