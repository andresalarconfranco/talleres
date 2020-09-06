using Javeriana.Pica.ApplicationCore.Entities;

namespace Javeriana.Pica.ApplicationCore
{
    public class CatalogType : BaseEntity
    {
        public string Type { get; private set; }
        public CatalogType(string type)
        {
            Type = type;
        }
    }
}