using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BadCompositeMapping.Domain;

using NHibernate.Mapping.ByCode.Conformist;


namespace BadCompositeMapping.DomainMapping
{
    class CategoryMapping : ClassMapping<Category>
    {
        public CategoryMapping()
        {            
            Id(x => x.CategoryId);
            Property(x => x.CategoryName);
        }
    }
}
