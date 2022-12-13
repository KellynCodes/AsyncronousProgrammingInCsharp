namespace AsyncronousProgramming
{
    internal class Threading
    {
        // This is the entry point of a C# program  
        public static void SyncronousProgrammingWithThreadExampleOne()
        {
            // Main execution starts here  
            Console.WriteLine("Main thread starts here.");

            // This method takes 4 seconds to finish.  
            DoSomeHeavyLifting();

            // This method doesn't take anytime at all.  
            DoSomething();

            // Execution ends here  
            Console.WriteLine("Main thread ends here.");
            Console.ReadKey();
        }

        public static void DoSomeHeavyLifting()
        {
            Console.WriteLine("I'm lifting a truck!!");
            Thread.Sleep(1000);
            Console.WriteLine("Tired! Need a 3 sec nap.");
            Thread.Sleep(1000);
            Console.WriteLine("1....");
            Thread.Sleep(1000);
            Console.WriteLine("2....");
            Thread.Sleep(1000);
            Console.WriteLine("3....");
            Console.WriteLine("I'm awake.");
        }
        public static void DoSomething()
        {
            Console.WriteLine("Hey! DoSomething here!");
            for (int i = 0; i < 20; i++)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine("I'm done.");
        }


        public static void AsyncronousProgrammingWithThreadExampleOne()
        {
            // Main execution starts here  
            Console.WriteLine("Main thread starts here.");

            // Create a thread   
            Thread backgroundThread = new (new ThreadStart(DoSomeHeavyLifting));
            // Start thread  
            backgroundThread.Start();

            // This method doesn't take anytime at all.  
            DoSomething();

            // Execution ends here  
            Console.WriteLine("Main thread ends here.");
            Console.ReadKey();
        }

        /* ========================== Another Example ==========================*/

        public static void AsyncronousProgrammingWithThreadExampleTwo()
        {
            // Create a secondary thread by passing a ThreadStart delegate  
            Thread workerThread = new(new ThreadStart(Print));
            // Start secondary thread  
            workerThread.Start();

            // Main thread : Print 1 to 10 every 0.2 second.   
            // Thread.Sleep method is responsible for making the current thread sleep  
            // in milliseconds. During its sleep, a thread does nothing.  
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(200);
            }

            Console.ReadKey();
        }

        /// <summary>  
        ///  This code is executed by a secondary thread  
        /// </summary>  
        static void Print()
        {
            for (int i = 11; i < 20; i++)
            {
                Console.WriteLine($"Worker thread: {i}");
                Thread.Sleep(1000);
            }
        }


        public static void PrintJob(object data)
        {
            Console.WriteLine("Background PrintJob started.");
            Thread.Sleep(1000);
            Console.WriteLine("PrintJob still printing...");
            Console.WriteLine($"Data: {data}");
            Thread.Sleep(1000);
            Console.WriteLine("PrintJob finished.");
            // Pass a class object to a worker thread  
          
        }

        public static void PrintPerson(object data)
        {

         
            Console.WriteLine("Background PrintPerson started.");
            Thread.Sleep(1000);
            Console.WriteLine("PrintPerson still printing...");
            Person person = (Person)data;
            Console.WriteLine($"Person {person._name} is a {person._sex} of {person._age} age.");
            Thread.Sleep(1000);
            Console.WriteLine("PrintPerson finished.");
        }

    }
    public class Person
    {
        public string _name;
        public int _age;
        public string _sex;

        public Person(string name, int age, string sex)
        {
            _name = name;
            _age = age;
            _sex = sex;
        }
    }
}

