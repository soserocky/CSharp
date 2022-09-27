using System;

namespace OOPS_Concepts
{
    public class Program
    {
        static void Main(string[] args)
        {
            PolymorphismDemo();

            //MyCollectionClass list = new MyCollectionClass();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //list.Add(5);
            //var enumerator = list.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
            //CustomIteratorDemo.Demo(c);

            Console.Read();
        }

        private static void PolymorphismDemo()
        {
            //First, Let's define two terms for better understanding.
            //Consider: Animal a = new Tiger();
            //*top - class used in the reference name - Animal 
            //*bottom - class used while actually instantiating the concrete class - Tiger

            //SCENARIO 1:
            Console.WriteLine("Scenario 1");
            Feline a = new Feline();
            Console.WriteLine(a.Name);
            a.Eat();
            Console.WriteLine(a.Weight); 
            Console.WriteLine("-------------------------");

            //SCENARIO 2:
            Console.WriteLine("Scenario 2");
            Animal b = new Tiger();
            Console.WriteLine(b.Name); 
            b.Eat();
            Console.WriteLine(b.Weight);
            Console.WriteLine("-------------------------");

            //SCENARIO 3:
            Console.WriteLine("Scenario 3");
            Animal c = new Tiger();
            Console.WriteLine((c as Tiger).Name); 
            (c as Tiger).Eat(); 
            Console.WriteLine((c as Tiger).Weight); 
            Console.WriteLine("-------------------------");

            //SCENARIO 4:
            Console.WriteLine("Scenario 4");
            Tiger d = new Tiger();
            Console.WriteLine((d as Animal).Name); 
            (d as Animal).Eat(); 
            Console.WriteLine((d as Animal).Weight); 
            Console.WriteLine("-------------------------");

        }
    }
}
