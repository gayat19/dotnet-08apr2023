using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication
{
    internal class Provider
    {
        IRepo manage;
        ProductRuleBL productRule;
        public Provider()
        {
            manage = new ManageProduct();
            productRule = new ProductRuleBL(manage);
        }
        public void AddProduct()
        {
            Product product = new Product();
            product.TakeProductDetails();
            if(productRule.Add(product) != null)
            {
                Console.WriteLine("Product Added successfully");
            }
        }
        public void ListProodcts()
        {
            foreach (var item in productRule.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
