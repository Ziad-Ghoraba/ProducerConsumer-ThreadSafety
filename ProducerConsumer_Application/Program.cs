namespace ProducerConsumer_Application
{
    internal class Program
    {
        // Shared resources
        private static readonly Queue<int> buffer = new Queue<int>();
        private static readonly int bufferSize = 10;
        private static readonly object lockObject = new object();
        private static int itemCount = 0;

        // Random generator for simulating delays
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Producer-Consumer Starting...");

            // Create multiple producers and consumers
            Thread producer1 = new Thread(() => Producer("Producer 1"));
            Thread producer2 = new Thread(() => Producer("Producer 2"));
            Thread consumer1 = new Thread(() => Consumer("Consumer 1"));
            Thread consumer2 = new Thread(() => Consumer("Consumer 2"));

            // Start the threads
            producer1.Start();
            producer2.Start();
            consumer1.Start();
            consumer2.Start();

            // Wait for all threads to complete
            producer1.Join();
            producer2.Join();
            consumer1.Join();
            consumer2.Join();

            Console.WriteLine("All threads completed execution.");
            Console.ReadLine();
        }

        /// <summary>
        /// Simulates a producer that adds items to the buffer.
        /// </summary>
        /// <param name="name">Name of the producer for logging purposes.</param>
        static void Producer(string name)
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(random.Next(100, 300)); // Simulate production delay
                lock (lockObject)
                {
                    while (buffer.Count >= bufferSize)
                    {
                        Console.WriteLine($"{name}: Buffer is full, waiting...");
                        Monitor.Wait(lockObject); // Wait until there's space in the buffer
                    }

                    itemCount++;
                    buffer.Enqueue(itemCount);
                    Console.WriteLine($"{name} produced item: {itemCount}");
                    Log($"{name} produced item: {itemCount}");

                    // Print current buffer state
                    PrintBufferState();

                    Monitor.PulseAll(lockObject); // Notify consumers
                }
            }
        }

        /// <summary>
        /// Simulates a consumer that removes items from the buffer.
        /// </summary>
        /// <param name="name">Name of the consumer for logging purposes.</param>
        static void Consumer(string name)
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(random.Next(150, 350)); // Simulate consumption delay
                lock (lockObject)
                {
                    while (buffer.Count == 0)
                    {
                        Console.WriteLine($"{name}: Buffer is empty, waiting...");
                        Monitor.Wait(lockObject); // Wait until there are items to consume
                    }

                    int item = buffer.Dequeue();
                    Console.WriteLine($"{name} consumed item: {item}");
                    Log($"{name} consumed item: {item}");

                    // Print current buffer state
                    PrintBufferState();

                    Monitor.PulseAll(lockObject); // Notify producers
                }
            }
        }

        /// <summary>
        /// Logs messages to a file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        static void Log(string message)
        {
            lock (lockObject) // Ensure thread-safe logging
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
        }

        /// <summary>
        /// Prints the current state of the buffer to the console.
        /// </summary>
        static void PrintBufferState()
        {
            Console.WriteLine("Current Buffer State: [" + string.Join(", ", buffer) + "]");
        }
    }
}
