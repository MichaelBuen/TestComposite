using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate.Mapping.ByCode.Conformist;


using GoodCompositeMapping.Domain;


namespace GoodCompositeMapping.DomainMapping
{
    class ProductMapping : ClassMapping<Product>
    {
        public ProductMapping()
        {
            Id(x => x.ProductId);
            Property(x => x.ProductName);
        }
    }
}
