using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Events
{
    public delegate void MyDelegate(int hours, string name);
    public class AnonymousObjects
    {
        public static void Demo()
        {
            //Conventional way of defining and invoking a delegate
            //MyDelegate myDel1 = new MyDelegate(DoWork);
            //myDel1(8, "sabya");

            //New way 1: Anonymous Method Delegates
            //Note: In the below code, we can not substitute the type - 'MyDelegate' with 'var'.
            //Since we are using an anonymous delegate, it has to infer the type from somewhere.
            //Hence the explicit type specification during delegate definition.
            MyDelegate myDel2 = delegate(int hours, string name)
            {
                Console.WriteLine($"Number of hours worked by {name}: {hours}");
            };

            myDel2(1, "Raj");


            //New way 2: Lambda Delegates
            //Departure from the conventional way of writing code
            MyDelegate myDel3 = null;
            myDel3 += (x, y) => 
                       { 
                          Console.WriteLine($"Number of hours worked by {y}: {x}"); 
                       };


        }

        public static void DoWork(int hours, string name)
        {
            Console.WriteLine($"Number of hours worked by {name}: {hours}");
        }
    }
}
