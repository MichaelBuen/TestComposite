using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NHibernate.Mapping.ByCode.Conformist;
using GoodCompositeMapping.Domain;


namespace GoodCompositeMapping.DomainMapping
{
    class ProductCategoryMapping : ClassMapping<ProductCategory>
    {
        public ProductCategoryMapping()
        {
            ComponentAsId(
                i => i.ProductCategoryIdentifier, 
                c =>
                {
                    c.Property(x => x.ProductId);
                    c.Property(x => x.CategoryId);
                });

            ManyToOne(x => x.Product, m =>
            {
                m.Column("ProductId");
                m.Update(false);
                m.Insert(false);                
            });

            ManyToOne(x => x.Category, m =>
            {
                m.Column("CategoryId");
                m.Update(false);
                m.Insert(false);                
            });

            Property(x => x.CustomizedProductCategoryDescription);
        }
    }
}
