using System;
using System.Threading;

namespace H2SyncThread
{
    class Program
    {
        static int sum = 0;
        static object _lock = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(StarSign);
            Thread t2 = new Thread(HashtagSign);

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.ReadLine();
        }
        #region Opgave 1
        static void AddTwo()
        {
            while (true)
            {
                sum += 2;
                Console.WriteLine($"Plus 2: {sum}");
                Thread.Sleep(1000);
            }
        }
        static void MinusOne()
        {
            while (true)
            {
                Interlocked.Decrement(ref sum);
                Console.WriteLine($"Minus 1 {sum}");
                Thread.Sleep(1000);
            }
        }
        #endregion
        #region Opgave 2
        static void StarSign()
        {
            while (true)
            {
                string stars = "*";
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write(stars);
                        Interlocked.Increment(ref sum);

                    }
                    Console.WriteLine($"Count: {sum}");
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(1000);
            }


        }
        static void HashtagSign()
        {
            while (true)
            {

                string hashtag = "#";
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write(hashtag);
                        Interlocked.Increment(ref sum);
                    }

                    Console.WriteLine($"Count: {sum}");
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
