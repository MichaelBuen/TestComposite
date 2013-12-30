using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCompositeMapping.Domain
{
    public class ProductCategory
    {
        ProductCategoryIdentifier _productCategoryIdentifier = new ProductCategoryIdentifier();
        public virtual ProductCategoryIdentifier ProductCategoryIdentifier
        {
            get { return _productCategoryIdentifier; }
            set { _productCategoryIdentifier = value; }
        }


        //// To enforce single source-of-truth when creating product category, set both Product and Category properties setter as protected.
        //// When assigning Product and Category, it must be done through the composite key class, i.e. through ProductCategoryIdentifier above


        public virtual Product Product { get; protected set; }
        public virtual Product Category { get; protected set; }
       
        public virtual string CustomizedProductCategoryDescription { get; set; }
    }
}
