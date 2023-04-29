namespace UnderstandingDelegateApp
{
    internal class Program
    {
        List<Product> products = new List<Product>()
            {
                new Product{Id=101,Name="ABC",CategoryId=1},
                new Product{Id=102,Name="XYZ",CategoryId=2},
                new Product{Id=103,Name="LMN",CategoryId=2},
                new Product{Id=104,Name="EFG",CategoryId=3},
            };
        //delegate void SampleDelegate<T>(T num1, T num2);
        //void Add(int n1, int n2)
        //{
        //    int sum = n1 + n2;
        //    Console.WriteLine("The sum is "+sum);
        //}
        void Product(int n1, int n2)
        {
            int sum = n1 * n2;
            Console.WriteLine("The product is " + sum);
        }
        void AssignDelegate()
        {
            //SampleDelegate<int> myDel = new SampleDelegate<int>(Add);
            //SampleDelegate<int> myDel = delegate (int n1, int n2)
            //{
            //    int sum = n1 + n2;
            //    Console.WriteLine("The sum is " + sum);
            //};
            //SampleDelegate<int> myDel = (n1, n2) => Console.WriteLine($"The sum is {n1+n2}");
            //Action<int,int> myDel = (n1, n2) => Console.WriteLine($"The sum is {n1 + n2}");
            //myDel += Product;
            //UseDelegate(myDel);
            Func<int, string> doIT = (num1) => $"The incremented value is {num1++}";
            Console.WriteLine(doIT(100));
            Predicate<int> checkAge = (num1) => num1 > 18;
            Console.WriteLine("Is the user eligible to vote "+checkAge(22));
        }
        void UsingDelegates()
        {
            List<Product> products = new List<Product>()
            {
                new Product{Id=101,Name="ABC",CategoryId=1},
                new Product{Id=102,Name="XYZ",CategoryId=2},
                new Product{Id=103,Name="LMN",CategoryId=2},
                new Product{Id=104,Name="EFG",CategoryId=3},
            };
            //Predicate<Product> checkProd = (prod) => prod.Name == "XYZ";
            //Product myProduct = products.Find(checkProd);
            //Product myProduct = products.Find((prod) => prod.Name == "XYZ");
            //var myProduct = from p in products where p.Name == "XYZ" select p;
            //Console.WriteLine(myProduct.ToList()[0]);
            var myProduct = products
                                .FirstOrDefault(p => p.Name == "XYZ");
            Console.WriteLine(myProduct);
        }
        //void UseDelegate(SampleDelegate<int> del)
        //{
        //    del(100, 200);
        //}
        void UseDelegate(Action<int, int> del)
        {
            del(100, 200);
        }
        void UnderstandingLINQ()
        {
            //int[] numbers = { 100, 45, 78, 90, 3, 49, 12 };
            ////var myNumbers = from n in numbers where n < 50 select n;
            //var myNumbers = numbers.Where(n => n < 50);
            //foreach (var item in myNumbers)
            //{
            //    Console.WriteLine(item);
            //}
            //var myProducts = from product in products orderby product.Name select product;
            //var myProducts = products.OrderBy(p => p.Name);
            //foreach (var item in myProducts)
            //{
            //    Console.WriteLine(item);
            //}
            var myProducts = from product in products
                             group product by product.CategoryId into productgrouped
                             select productgrouped;
            foreach (var item in myProducts)
            {
                Console.WriteLine(item.Key);
                foreach (var data in item)
                {
                    Console.WriteLine(data);
                }
                Console.WriteLine("-------------------");
            }
        }

        static void Main(string[] args)
        {
            new Program().UnderstandingLINQ();
        }
    }
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
    //class Product
    //{
    //    public string Name { get; set; }
    //    public int CategoryId { get; set; }
    //}

    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}