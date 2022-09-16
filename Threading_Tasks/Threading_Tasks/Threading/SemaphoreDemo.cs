namespace Threading
{
    internal class SemaphoreDemo
    {
        private static Semaphore _semaphore = new Semaphore(1, 2);
        internal static void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(ReadFile).Start();
            }

            Thread.Sleep(3000);
            _semaphore.Release();
        }

        private static void ReadFile()
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started reading");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished reading");
            _semaphore.Release();
        }
    }
}