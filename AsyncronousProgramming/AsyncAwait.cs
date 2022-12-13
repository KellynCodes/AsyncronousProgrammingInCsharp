namespace AsyncronousProgramming
{
    internal class AsyncAwait
    {
        public static async Task Container()
        {
            LongProcess();
            ShortProcess();

            Task<int> result = LongProcessOne();
            ShortProcessOne();

            int val = await result; // wait untitle get the return value

            DisplayReturnedValue(val);
            Console.ReadKey();

        }

        static async void LongProcess()
        {
            Console.WriteLine("LongProcess Started");
            await Task.Delay(4000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");

            //do something here

            Console.WriteLine("ShortProcess Completed");
        }

        /*  ========================second example wich returns a value========================*/

        static async Task<int> LongProcessOne()
        {
            Console.WriteLine("LongProcess Started");

            await Task.Delay(4000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

            return 10;
        }

        static void ShortProcessOne()
        {
            Console.WriteLine("ShortProcess Started");
            //do something here
            Console.WriteLine("ShortProcess Completed");
        }
        public static void DisplayReturnedValue(int value) => Console.WriteLine(value);


        public static async Task FunWithAsyncAwait()
        {
            Console.WriteLine(" Fun With Async ===> Await");
            SyncronousThread();
           await AsyncronousThread();
        }

        static void SyncronousThread()
        {

            Console.WriteLine(DoWork());
            Console.WriteLine("Syncronous thread Completed");
            static string DoWork()
            {
                Thread.Sleep(5000);
                return "Done with work!";
            }
        }

        static async Task AsyncronousThread()
        {
            string message = await DoWorkAsync();
            Console.WriteLine(message);
            static async Task<string> DoWorkAsync()
            {
                return await Task.Run(() =>
                {
                    Thread.Sleep(5000);
                    return "Done with work!. Asyncrous Thread completed";
                });
            }

        }
    }
}
