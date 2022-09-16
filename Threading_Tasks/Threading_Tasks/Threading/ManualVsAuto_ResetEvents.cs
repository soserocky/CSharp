using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    //Popular implementation when you have multiple funcitons and want other functions to NOT execute
    //until one function finishes.
    //Example - File read and write. One thread writes to the file and other threads read from it.
    internal class ManualVsAuto_ResetEvents
    {
        private static ManualResetEvent _mreObj = new ManualResetEvent(false);
        private static AutoResetEvent _areObj = new AutoResetEvent(true);

        //When threads encounter the WaitOne() function, they check the state
        //If state is false, then they wait until the state is "true" again
        //Once the state becomes "true" again, only one thread gets access
        //and the state is set to "false" again and the other threads wait
        //for the state to become "true" again and so on...
        internal static void Start()
        {
            //MyManualResetEventFunction();
            //MyAutoResetEventFunction();
        }

        private static void MyManualResetEventFunction()
        {
            new Thread(Write).Start();
            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }
        }
        private static void MyAutoResetEventFunction()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }
        }

        private static void Read()
        {
            //_mreObj.WaitOne();
            _areObj.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started reading");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished reading");
            _areObj.Set();
        }
        
        private static void Write()
        {
            _mreObj.Reset();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started writing");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished writing");
            _mreObj.Set();
        }
    }
}
