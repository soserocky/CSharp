using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    internal class ThreadSafety_Lock_Monitor
    {
        private static object _lock = new object(); 
        internal static void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                //new Thread(MyLockFunction).Start();
                //new Thread(MyMonitorFunction).Start();
            }
        }

        internal static void MyLockFunction()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} trying to acquire lock");
            lock (_lock)
            {
                try
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} successfully acquired lock");
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has started");
                    Thread.Sleep(5000);
                    throw new Exception();
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished");
                }
                catch (Exception)
                {
                }
                finally 
                {
                    
                }
            }
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} going to release lock");
        }

        internal static void MyMonitorFunction()
        {
            try
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} trying to acquire lock");
                Monitor.Enter(_lock);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} successfully acquired lock");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has started");
                Thread.Sleep(5000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished");
            }
            catch (Exception)
            {
            }
            finally
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} going to release lock");
                Monitor.Exit(_lock);
            }
        }
    }
}
