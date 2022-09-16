namespace Threading
{
    internal class MutexDemo
    {
        private static Mutex _mutex = new Mutex();
        internal static void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(ReadFile).Start();
            }

            Thread.Sleep(2000);
            _mutex.ReleaseMutex();
            //The above line throws an exception because the mutex object is being released from a thread
            //that does not currently have the "lock" over it.
        }

        private static void ReadFile()
        {
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started reading");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished reading");
            _mutex.ReleaseMutex();
        }
    }
}