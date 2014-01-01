using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComposite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tested VS integrated git commit

            bool testGood = true;

            if (testGood)
            {
                var m = GoodCompositeMapping.Test.LoadModel(1);

                //GoodCompositeMapping.Test.AddProductCategory(1, 1);

                //var x = GoodCompositeMapping.Test.QueryModel();
                //foreach (var item in x)
                //{
                //    Console.WriteLine("{0} {1} {2} {3}",
                //        item.ProductCategory.ProductCategoryIdentifier.ProductId,
                //        item.ProductCategory.Product.ProductId,
                //        item.ProductCategory.Product.ProductName,
                //        item.ModelDescription);
                //}


                //var n = GoodCompositeMapping.Test.AddModel();
                Console.WriteLine("Id: {0}", n);
            }
            else
            {
                var m = BadCompositeMapping.Test.LoadModel(1);

                //var n = BadCompositeMapping.Test.AddModel();
                //Console.WriteLine("Id: {0}", n);
            }




            
            

            Console.WriteLine("Working");
            Console.ReadKey();
        }
    }
}
