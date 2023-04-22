using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepo : IRepo<int, Product>
    {
        static Dictionary<int,Product> products = new Dictionary<int,Product>();
        public Product Add(Product item)
        {
            if (products.ContainsKey(item.Id))
                return null;
            products.Add(item.Id, item);
            return item;
        }

        public Product Delete(int key)
        {
            if (!products.ContainsKey(key))
                return null;
            products.Remove(key);
            return products[key];
        }

        public Product Edit(Product item)
        {
           if (products.ContainsKey(item.Id))
                return null;
            products[item.Id] = item;
            return item;
        }

        public Product Get(int key)
        {
            if (!products.ContainsKey(key))
                return null;
            return products[key];
        }

        public ICollection<Product> GetAll()
        {
            if (products.Count == 0)
                return null;
            return products.Values.ToList();
        }
    }
}
