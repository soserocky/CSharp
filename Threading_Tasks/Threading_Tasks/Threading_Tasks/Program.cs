using System;
using Tasks;
using Threading;

namespace Threading_Tasks 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ThreadingDemo.Start();
            TasksDemo.Start();
            Console.Read();
        }
    }
}