using ShoppingModelLibrary;
using System.Diagnostics;

namespace SampleApplication
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Product product = new Product();
            //product[0] = "ABC";
            //product.TakeProductDetails();
            //Console.WriteLine(product);
            Provider provider = new Provider();
            provider.AddProduct();
            provider.ListProodcts();
        }
    }
}