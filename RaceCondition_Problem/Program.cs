namespace RaceCondition_Problem
{
    /// <summary>
    /// Demonstrates a producer-consumer problem with shared data (count) and potential race conditions.
    /// </summary>
    internal class Program
    {
        // Shared resource (count) accessed by both Producer and Consumer threads
        private static int count;

        static void Main(string[] args)
        {
            // Initialize the shared resource
            count = 0;

            // Create and initialize producer and consumer threads
            Thread thread1 = new Thread(() => Producer());
            Thread thread2 = new Thread(() => Consumer());

            // Start the producer and consumer threads
            thread1.Start();
            thread2.Start();

            // Ensure the main thread waits for the completion of both threads
            thread1.Join();
            thread2.Join();

            // Output the final value of the shared resource
            Console.WriteLine(count);

            // Wait for user input to keep the console open
            Console.ReadLine();
        }

        /// <summary>
        /// Simulates a producer operation that increments the shared resource.
        /// </summary>
        static void Producer()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                count++; // Increment the shared resource
            }
        }

        /// <summary>
        /// Simulates a consumer operation that decrements the shared resource.
        /// </summary>
        static void Consumer()
        {
            for (int i = 0; i < 1000000; ++i)
            {
                count--; // Decrement the shared resource
            }
        }

        /// <note>
        /// This program demonstrates a race condition due to the lack of synchronization when accessing the shared resource (`count`).
        /// The issue becomes evident with high iteration values (e.g., `i < 1000000`), as multiple threads simultaneously read and write to `count`.
        /// With lower iteration values (e.g., `i < 100`), the program might appear to work correctly because the threads are less likely to 
        /// conflict, but this is not guaranteed. To fix the issue, synchronization mechanisms such as locks or other thread-safety 
        /// techniques must be implemented.
        /// </note>
    }
}
