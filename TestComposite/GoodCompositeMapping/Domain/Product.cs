using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCompositeMapping.Domain
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
    }
}
