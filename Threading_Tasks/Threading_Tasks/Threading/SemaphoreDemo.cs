namespace Threading
{
    internal class SemaphoreDemo
    {
        //The count on a semaphore is decremented each time a thread enters the semaphore,
        //and incremented when a thread releases the semaphore. When the count is zero,
        //subsequent requests block until other threads release the semaphore.
        //When all threads have released the semaphore, the count is at the maximum value specified
        //when the semaphore was created.
        //NOTE: The semaphore count should never exceed the maximum count specified at the time of semaphore creation
        private static Semaphore _semaphore = new Semaphore(1, 1);
        internal static void Start()
        {
            for (int i = 0; i < 1; i++)
            {
                new Thread(ReadFile).Start();
            }
        }

        private static void ReadFile()
        {
            _semaphore.WaitOne(); //The semaphore count is decremented here 
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started reading");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished reading");
            Console.WriteLine($"Semaphore release count: {_semaphore.Release()} in ReadFile function");
            //_semaphore.Release() increments the semaphore count
        }
    }
}