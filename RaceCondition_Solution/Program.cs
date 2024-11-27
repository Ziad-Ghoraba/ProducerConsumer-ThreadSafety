namespace ProducerConsumer_Solution
{
    /// <summary>
    /// Demonstrates a thread-safe solution to the producer-consumer problem using a mutex lock.
    /// </summary>
    internal class Program
    {
        // Shared resource accessed by producer and consumer
        private static int count;

        // Lock object used to synchronize access to the shared resource
        private static object lock1;

        static void Main(string[] args)
        {
            // Initialize shared resource and lock
            count = 0;
            lock1 = new object();

            // Create and initialize threads for producer and consumer
            Thread thread1 = new Thread(() => Producer());
            Thread thread2 = new Thread(() => Consumer());

            // Start threads
            thread1.Start();
            thread2.Start();

            // Wait for threads to complete execution
            thread1.Join();
            thread2.Join();

            // Output the final value of the shared resource
            Console.WriteLine(count);

            // Keep the console open for user input
            Console.ReadLine();
        }

        /// <summary>
        /// Simulates the producer's operation by incrementing the shared resource.
        /// </summary>
        static void Producer()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                // Lock ensures mutual exclusion while accessing `count`
                lock (lock1)
                {
                    count++;
                }
            }
        }

        /// <summary>
        /// Simulates the consumer's operation by decrementing the shared resource.
        /// </summary>
        static void Consumer()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                // Lock ensures mutual exclusion while accessing `count`
                lock (lock1)
                {
                    count--;
                }
            }
        }
    }
}
