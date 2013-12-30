using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCompositeMapping.Domain
{
    public class ProductCategory
    {

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }

        public virtual string CustomizedProductCategoryDescription { get; set; }        

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as ProductCategory;
            if (t == null)
                return false;
            if (Product == t.Product && Category == t.Category)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (Product.ProductId + "|" + Category.CategoryId).GetHashCode();
        }
    }
}
