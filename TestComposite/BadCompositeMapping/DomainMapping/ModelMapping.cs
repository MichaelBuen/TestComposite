
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NHibernate.Mapping.ByCode.Conformist;
using BadCompositeMapping.Domain;

namespace BadCompositeMapping.DomainMapping
{
    class ModelMapping : ClassMapping<Model>
    {
        public ModelMapping()
        {
            Id(x => x.ModelId, m => m.Generator(NHibernate.Mapping.ByCode.Generators.Identity));

            ManyToOne(x => x.ProductCategory, c => c.Columns(x => x.Name("ProductId"), x => x.Name("CategoryId")));

            Property(x => x.ModelDescription);
        }
    }
}
