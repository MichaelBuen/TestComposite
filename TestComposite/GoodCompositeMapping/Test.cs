
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NHibernate;
using NHibernate.Linq;

using GoodCompositeMapping.Domain;



namespace GoodCompositeMapping
{
    public static class Test
    {
        public static Model LoadModel(int id)
        {
            using (var session = SessionMapper.Mapper.SessionFactory.OpenSession())
            {                
                //// Don't read from ProductId from Product, this will unecessarily fetch the ProductCategory object.
                //// Think Edit, when getting the values(i.e. the IDs) of the foreign keys, their whole object must not be fetched.
                // Console.WriteLine("{0} {1}", x.ProductCategory.Product.ProductId, x.ModelDescription);                


                // Read the ID from Composite Key's separate class(ProductCategoryIdentifier) instead
                // ,this way the whole object of ProductCategory won't be prematurely fetched.
                var x = session.Load<Model>(1);
                Console.WriteLine("{0} {1}", x.ProductCategory.ProductCategoryIdentifier.ProductId, x.ModelDescription);
                //Console.WriteLine("{0} {1}", x.ProductCategory.Product.ProductName, x.ModelDescription);                



                return x;
            }        
        }


        public static List<Model> QueryModel()
        {
            using (var session = SessionMapper.Mapper.SessionFactory.OpenSession())
            {
                var l = session.Query<Model>()
                    
                    .Fetch(x => x.ProductCategory)
                    .ThenFetch(x => x.Product)

                    .Fetch(x => x.ProductCategory)
                    .ThenFetch(x => x.Category)

                    .ToList();

                return l;
            }
        }



        public static string AddModel()
        {
            using (var session = SessionMapper.Mapper.SessionFactory.OpenSession())
            {
                var m = new Model
                {
                    ProductCategory = session.Load<ProductCategory>(new ProductCategoryIdentifier { ProductId = 1, CategoryId = 2 }),                    
                    ModelDescription = "Good " + DateTime.Now.ToString()
                };

                session.Save(m);
                session.Flush();

                return m.ModelId + " " + m.ModelDescription;
            }
        }


        public static string AddProductCategory(int productId, int categoryId)
        {
            using (var session = SessionMapper.Mapper.SessionFactory.OpenSession())
            {
                var m = new ProductCategory
                {
                    ProductCategoryIdentifier = new ProductCategoryIdentifier { ProductId = 1, CategoryId = 1 },
                    CustomizedProductCategoryDescription = "Shoe ideal for summer"
                };

                session.Save(m);
                session.Flush();

                return "yay";
            }
        }


    }
}
