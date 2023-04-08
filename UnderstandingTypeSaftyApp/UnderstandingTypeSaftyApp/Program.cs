using System.Collections;

namespace UnderstandingTypeSaftyApp
{
    internal class Program
    {
        static void UnderstandingCollection()
        {
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(12.4f);
            list.Add("sfhsdj");
            list.Add(new { Id = 101, Nam = "Ramu" });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
        static void UnderstandingGenericList()
        {
            List<int> list = new List<int>();   
            list.Add(10);
            list.Add(45);
            list.Add(78);
            list.Add(12);
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            UnderstandingGenericList();
        }
    }
}