
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NHibernate;


using BadCompositeMapping.Domain;

using NHibernate.Linq;


namespace BadCompositeMapping
{
    public static class Test
    {
        public static Model LoadModel(int id)
        {
            using (var session = SessionMapper.Mapper.SessionFactory.OpenSession())
            {
                var x = session.Load<Model>(1);
                Console.WriteLine("{0} {1}", x.ProductCategory.Product.ProductId, x.ModelDescription);
                
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
                    ProductCategory = session.Load<ProductCategory>(new ProductCategory { Product = session.Load<Product>(1), Category = session.Load<Category>(2) }),
                    ModelDescription = "Bad " + DateTime.Now.ToString()
                };

                session.Save(m);
                session.Flush();

                return m.ModelId + " " +  m.ModelDescription;
            }
        }

    
    }
}
