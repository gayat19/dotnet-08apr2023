namespace UnderstandingEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product{Name="Coke",Price=20,CategoryId=1,Quantity=5},
                new Product{Name="Maggie",Price=15,CategoryId=2,Quantity=3},
                new Product{Name="Fanta",Price=21,CategoryId=1,Quantity=1}
            };
            ShopContext context = new ShopContext();
            context.Products.AddRange(products);
            context.SaveChanges();
            foreach (Product product in context.Products)
            {
                Console.WriteLine(product.Name);
            }
            //Console.WriteLine("Hello, World!");
        }
    }
}