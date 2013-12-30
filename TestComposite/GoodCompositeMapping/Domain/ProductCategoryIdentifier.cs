using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCompositeMapping.Domain
{
    [Serializable]
    public class ProductCategoryIdentifier
    {
        public virtual int ProductId { get; set; }
        public virtual int CategoryId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as ProductCategoryIdentifier;
            if (t == null)
                return false;
            if (ProductId == t.ProductId && CategoryId == t.CategoryId)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (ProductId + "|" + CategoryId).GetHashCode();
        }
    }
}
