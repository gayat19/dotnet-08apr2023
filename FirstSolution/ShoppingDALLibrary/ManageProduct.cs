using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class ManageProduct : IRepo
    {
        //Product[] products;
        List<Product> products;
        public ManageProduct()
        {
            //products = new Product[100];
            products = new List<Product>();
        }
        public Product Add(Product product)
        {
            int id = 0;
            if (products.Count == 0)
                id = 100;
            else
                id =products[products.Count-1].Id+1;
            product.Id = id;
            products.Add(product);
            return product;
        }

        public Product Delete(int id)
        {
           Product product = Get(id);
            if(product != null)
            {
                products.Remove(product);
                return product;
            }
            return null;
        }

        public Product Edit(Product product)
        {
            Product myProduct = Get(product.Id);
            if (product != null)
            {
                myProduct.Name = product.Name;
                myProduct.Price = product.Price;
                return product;
            }
            return null;
        }

        public Product Get(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id==id)
                {
                    return products[i];
                }
            }
            return null;
        }

        public Product[] GetAll()
        {
            if (products.Count == 0)
                return null;
            return products.ToArray();
        }
    }
}