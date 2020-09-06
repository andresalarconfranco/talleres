using Javeriana.Pica.ApplicationCore.Entities;
using Javeriana.Pica.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Javeriana.Pica.ApplicationCore.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IRepository<CatalogItem> _itemRepository;

        public CatalogService(IRepository<CatalogItem> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IList<CatalogItem> GetCatalogItems()
        {
            return _itemRepository.ListAll();
        }
    }
}
