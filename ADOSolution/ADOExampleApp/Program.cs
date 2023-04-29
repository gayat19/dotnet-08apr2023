namespace ADOExampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductContext productContext = new ProductContext();
            //Department department = new Department() { Name = "HR" };
            //Console.WriteLine("Object just created not added "+productContext.Entry(department).State);
            //productContext.Add(department);
            //Console.WriteLine("Object Added " + productContext.Entry(department).State);
            //productContext.SaveChanges();
            //Console.WriteLine("Save Changes done" + productContext.Entry(department).State);
            productContext.Departments.Remove(new Department { DeptId = 101 });
            productContext.SaveChanges();
            foreach (var item in productContext.Departments)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}