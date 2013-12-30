using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCompositeMapping.Domain
{
    public class Model
    {
        public virtual int ModelId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual string ModelDescription { get; set; }
    }
}
