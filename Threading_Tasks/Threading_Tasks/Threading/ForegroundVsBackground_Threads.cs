using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    internal class ForegroundVsBackground_Threads
    {
        //Foreground threads make the application wait till their execution is complete
        //Background threads terminate as the "main" application finishes
        public static void Start()
        {
            Console.WriteLine("Execution Starts");
            Thread t = new Thread(MyFunction);
            t.IsBackground = true;
            //The demo here is to illustrate that a thread created is a "foreground" thread by default
            //The program/application does not terminate until all the foreground threads have completed their executions
            //To demonstrtate, we create a thread and invoke it to run for around 10 seconds.
            //We see that the application does not terminate until the execution of the thread completes
            //But, when we do t.IsBackground = true;, the application terminates immediately as the "Main" method
            //finishes execution
            //NOTE: To see the program terminating before the background threads finishing,
            //ensure that you have no Console.Read() in the program/application execution.

            t.Start();
            Console.WriteLine("Execution Ends");
        }

        internal static void MyFunction()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}
