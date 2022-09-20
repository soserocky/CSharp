namespace Tasks
{
    public class TasksDemo
    {
        public async static void Start()
        {
            //var result1 = await Calculate1();
            //var result2 = await Calculate2();
            CancellationTokenSource cts = new CancellationTokenSource();
            await Task.Run(() => Calculate4(cts));
            var result3 = await Task.Run(() => Calculate3(cts.Token), cts.Token);
            Thread.Sleep(1000);
        }

        private async static Task<int> Calculate1()
        {
            Thread.Sleep(2000);
            await Task.Run(() => Console.WriteLine("Hello, World"));
            return 10;
        }
        private async static Task<int> Calculate2()
        {
            Thread.Sleep(2000);
            return await Task.Run(() => {
                Console.WriteLine("Hello, World");
                return 20;
            });
        }
        private async static Task<int> Calculate3(CancellationToken token)
        {
            return await Task.Run(() => {
                Thread.Sleep(7000);
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();

                Console.WriteLine("Hello, World");
                return 30;
            });
        }
        private static void Calculate4(CancellationTokenSource tokenSource)
        {
            Thread.Sleep(3000);
            tokenSource.Cancel();
        }
    }
}