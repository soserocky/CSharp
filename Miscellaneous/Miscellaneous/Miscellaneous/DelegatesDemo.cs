using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous
{
    internal class DelegatesDemo
    {
        internal static void Start()
        {
            EventDemo.Start();
            //MyDelegate sabya = DoWork;
            //MyDelegate sanjay = DoWork;

            //sabya.Invoke("Sabya", WorkType.Coding);
            //sanjay.Invoke("Sanjay", WorkType.Meetings);
        }

        internal static void DoWork(string name, WorkType w)
        {
            var verb = string.Empty;
            if (w == WorkType.Meetings) verb = "attending ";
            else if (w == WorkType.Golf) verb = "playing ";
            else verb = "";
            Console.WriteLine($"{name} is {verb}{w.ToString()}");
        }
    }

    public enum WorkType
    {
        Golf,
        Meetings,
        Running,
        Coding
    }
}
