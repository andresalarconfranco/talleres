using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Javeriana.Pica.Infrastructure.Data
{
    public class CatalogRepository : IRepository<CatalogItem>
    {
        private IList<CatalogItem> _catalogList;

        public CatalogRepository()
        {
            _catalogList = new List<CatalogItem>
                {
                    new CatalogItem(1,2,"Pica T-Shirt","T-Shirt",20000, "https://static.vecteezy.com/system/resources/previews/000/226/407/original/vector-646.jpg"),
                    new CatalogItem(1,2,"Pica Pants","Pants",80000, "https://cdn.shopify.com/s/files/1/0856/8732/products/www.imagehandler.net.png"),
                    new CatalogItem(1,2,"Pica Hoodie","Hoodie",80000, "https://www.dressinn.com/f/13725/137255204/tommy-hilfiger-straight-logo-hoodie.jpg")
                };
        }
        public CatalogItem Add(CatalogItem entity)
        {
            throw new NotImplementedException();
        }

        public CatalogItem Delete(CatalogItem entity)
        {
            throw new NotImplementedException();
        }

        public CatalogItem GetById(int id)
        {
            return _catalogList.FirstOrDefault(x => x.Id == id);
        }

        public IList<CatalogItem> ListAll()
        {
            return _catalogList;
        }

        public CatalogItem Update(CatalogItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
