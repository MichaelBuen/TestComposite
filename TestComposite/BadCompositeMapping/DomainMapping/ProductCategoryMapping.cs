using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NHibernate.Mapping.ByCode.Conformist;
using BadCompositeMapping.Domain;


namespace BadCompositeMapping.DomainMapping
{
    class ProductCategoryMapping : ClassMapping<ProductCategory>
    {
        public ProductCategoryMapping()
        {            
            ComposedId(
                c =>
                {                    
                    c.ManyToOne(x => x.Product, x => x.Column("ProductId"));
                    c.ManyToOne(x => x.Category, x => x.Column("CategoryId"));
                });

            Property(x => x.CustomizedProductCategoryDescription);
        }
    }
}
