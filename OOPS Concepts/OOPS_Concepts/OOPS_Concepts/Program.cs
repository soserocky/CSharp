using System;

namespace OOPS_Concepts
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PolymorphismDemo();

            MyCollectionClass list = new MyCollectionClass();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            //CustomIteratorDemo.Demo(c);

            Console.Read();
        }

        private static void PolymorphismDemo()
        {
            //Let's define two terms first for better understanding.
            //Consider: Animal a = new Tiger();
            //*top - class used in the reference name : Animal 
            //*bottom - class used while actually instantiating the concrete class: Tiger

            //--------------------------------------------------------------------------------------------------------------------------------//
            //SCENARIO 1:
            //Feline a = new Feline();
            //Console.WriteLine(a.Name); //Feline
            //a.Eat(); //Feline eats
            //Console.WriteLine(a.Weight); //400

            //In the above code, the CLR starts from the top - "Animal" class.
            //Starts checking from the top class in the hierarchical tree and moves down the hierarchical tree until it finds
            //an implementation of the "Eat" method in a class.
            //Also, if a class in the hierarchical tree has an implementation, it implements that code, but, however,
            //if the implementation is overriden in its child class then it goes to the child class implementation until the implementation
            //is not overriden further. In the above example, the checking starts from "Animal" and finds an implementation but since it finds
            //the method being overriden in "Feline" class it goes there. Now, in Feline class, there is an implementation and no further
            //override of the "Eat" method, it prints the "Feline" class implementation of the "Eat" method.
            //--------------------------------------------------------------------------------------------------------------------------------//


            //--------------------------------------------------------------------------------------------------------------------------------//
            //SCENARIO 2:
            //Tiger t = new Tiger();
            //Console.WriteLine(t.Name); //Feline
            //t.Eat(); //Feline eats
            //Console.WriteLine(t.Weight); //200

            //In the above, by-default, the top is always the TOPMOST class of the hierarchical tree - "Animal" class
            //The CLR starts from the bottom in the hierarchical tree and moves up the hierarchical tree
            //until it finds an implementation of the "Eat" method in a class. It implements that method.
            //Does not matter if the implementation has a "sealed override" marker to it.
            //For e.g, the "Tiger" class does not have a "Eat" method, the CLR moves up and reaches the "Feline" class.
            //The Feline class has a "sealed override" marker to it, but still gets executed in the above example.
            //--------------------------------------------------------------------------------------------------------------------------------//

            //THE ABOVE RULES ARE APPLIED IDENTICALLY TO PROPERTIES AS WELL.
            //WITH VARIABLES, ALL RULES REMAIN IDENTICAL, EXCEPT ONE. THE SLIGHT DIFFERENCE IS THAT VARIABLES CAN NOT BE OVERRIDEN.
            //HENCE, DURING DOWNWARD TRAVERSAL, IF A CLASS HAS THE VARIABLE THEN THAT VALUE IS USED.


            //SCENARIO 3:
            //Animal b = new Tiger();
            //Console.WriteLine((b as Tiger).Name); //Feline
            //(b as Tiger).Eat(); //Feline eats
            //Console.WriteLine((b as Tiger).Weight); //200

            //SCENARIO 3 IS TREATED IDENTICALLY BY THE CLR AS SCENARIO 2



            //SCENARIO 4:
            //Tiger c = new Tiger();
            //Console.WriteLine((c as Animal).Name); //Feline
            //(c as Animal).Eat(); //Feline eats
            //Console.WriteLine((c as Animal).Weight); //400

            //SCENARIO 4 IS TREATED IDENTICALLY BY THE CLR AS SCENARIO 1
        }
    }
}
