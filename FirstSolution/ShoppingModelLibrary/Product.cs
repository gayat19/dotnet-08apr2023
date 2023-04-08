namespace ShoppingModelLibrary
{
    public class Product:IEquatable<Product>
    {
        //int something;
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        //public int Something { get => something; set => something = value; }

        string[] suppliers = new string[3];
        public string this[int index]
        {
            get { return suppliers[index]; }
            set { suppliers[index] = value; }
        }
        public int this[string name]
        {
            get
            {
                for (int i = 0; i < suppliers.Length; i++)
                {
                    if (suppliers[i] == name)
                    {
                        return i;
                    }
                }
                return -1;
            }

        }
        public Product()
        {

        }

        public Product(int id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void TakeProductDetails()
        {
            int id;
            Console.WriteLine("Please enter the product Id");
            while (!int.TryParse(Console.ReadLine(), out id))
                Console.WriteLine("Invalid entry for ID");
            Id = id;
            Console.WriteLine("Please enter the product Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the product Price");
            Price = Convert.ToSingle(Console.ReadLine());
        }
        public void PrintProductDetails()
        {
            Console.WriteLine($"PRoduct Id {Id}, Product  Name {Name} Product Price ${Price}");
            Console.WriteLine("Suppliers for this product");
            foreach (var item in suppliers)
            {
                Console.WriteLine("\t" + item);
            }
        }
        public override string ToString()
        {
            return $"PRoduct Id {Id}, Product  Name {Name} Product Price ${Price}";
        }

        public bool Equals(Product? other)
        {
            if(this.Id==other.Id)
                return true;
            return false;
        }

        public static Product operator +(Product p1, Product p2)
        {
            Product result = p1;
            p1.Price += p2.Price;
            p1.Name += " " + p2.Name;
            return result;
        }
    }
}