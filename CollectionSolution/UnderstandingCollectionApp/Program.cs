using System.Collections;

namespace UnderstandingCollectionApp
{
    internal class Program
    {
        void UnderstandingTypeSafety()
        {
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add(123.4);
            list.Add(324.54f);//boxing float to object
            list.Add("567");
            list.Add("hafgsd");
            var sum =0;
            //dynamic num;
            //num = 100;
            //num = "hello";
            for (int i = 0; i < list.Count; i++)
            {
                sum += Convert.ToInt32(list[i]);//unboxig object to int
            }
        }
        void UnderstandingList()
        {
            List<double> list = new List<double>();
            list.Add(100);
            list.Add(123.4);
            list.Add(324.54f);
            var sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += Convert.ToInt32(list[i]);
            }
        }
        void UnderstandingCustomList()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee());
            employees[0].Id = 101;
            employees[0].Name = "Ramu";
            employees[0].Salary = 1006734;
            employees.Add(new Employee { Id = 102, Name = "Somu", Salary = 46456 });
            employees.Add(new Employee(103, "Bimu", 45756));
            employees.Sort();
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
            //List<int> numbers = new List<int> { 34, 7, 5, 234, 4576, 23, 230, 90, 100, 23 };
            //numbers.Sort();
            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}
        }
        void UnderstandingSet()
        {
            SortedSet<Employee> employees = new SortedSet<Employee>();
            Employee emp = new Employee();
            emp.Id = 101;
            emp.Name = "Ramu";
            emp.Salary = 1006734;
            employees.Add(emp);
            employees.Add(new Employee { Id = 102, Name = "Somu", Salary = 46456 });
            employees.Add(new Employee { Id = 102, Name = "Somu", Salary = 34534 });
            employees.Add(new Employee(103, "Bimu", 45756));
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
        }
        void UnderstandingDictionary()
        {
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
            Employee emp = new Employee();
            emp.Id = 101;
            emp.Name = "Ramu";
            emp.Salary = 1006734;
            employees.Add(101,emp);
            employees.Add(102,new Employee { Id = 102, Name = "Somu", Salary = 46456 });
            if(employees.ContainsKey(102))
                Console.WriteLine("Key already present");
            else
                employees.Add(102,new Employee { Id = 102, Name = "Somu", Salary = 34534 });
            employees.Add(103,new Employee(103, "Bimu", 45756));
            Console.WriteLine(employees[102]);
            foreach (var item in employees.Keys) {
                Console.WriteLine(employees[item]);
            }
        }
        void UnderstandingStack()
        {
            Stack<Employee> stack = new Stack<Employee>();
            Employee emp = new Employee();
            emp.Id = 101;
            emp.Name = "Ramu";
            emp.Salary = 1006734;
            stack.Push(emp);
            stack.Push(new Employee { Id = 102, Name = "Somu", Salary = 46456 });
            stack.Push(new Employee { Id = 102, Name = "Somu", Salary = 34534 });
            stack.Push(new Employee(103, "Bimu", 45756));
            int count = stack.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            Console.WriteLine(stack.Count);
        }
        static void Main(string[] args)
        {
            new Program().UnderstandingStack();
        }
    }
}