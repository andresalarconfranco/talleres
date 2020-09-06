using Javeriana.Pica.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Javeriana.Pica.ApplicationCore.Interfaces
{
    public interface ICatalogService
    {
        IList<CatalogItem> GetCatalogItems();
    }
}
