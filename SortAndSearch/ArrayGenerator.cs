using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace SortAndSearch
{
    public static class ArrayGenerator
    {
        private static int[] array;
        
        public static int[] NewArray(int n)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            
            array = new int[n];
            Fill();
            time.Stop();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Array generated in {0} milliseconds", time.ElapsedMilliseconds.ToString());
            return array;
        }

        static void Fill()
        {
            for(int x = 0; x <= array.Length; x += 10000)
            {
                if (x <= array.Length - 1)
                {
                    if (array.Length < 10000)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(Generate), new RandomNumberGenerationItems(x, array.Length));
                    }
                    else
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(Generate), new RandomNumberGenerationItems(x, 10000));
                    }
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Generate), new RandomNumberGenerationItems(x, array.Length % 10000 - 1));
                }
            }

            WaitForAllThreads();
        }

        static void Generate(object arrayInfo)
        {
            Random rand = new Random();
            for (int x = (arrayInfo as RandomNumberGenerationItems).Index; x <= (arrayInfo as RandomNumberGenerationItems).Index + (arrayInfo as RandomNumberGenerationItems).Length - 1; x++)
            {
                array[x] = rand.Next(1, array.Length);
            }
        }

        static void WaitForAllThreads()
        {
            while (true)
            {
                ThreadPool.GetMaxThreads(out int maxThreads, out int x);
                ThreadPool.GetAvailableThreads(out int availableThreads, out x);

                if(availableThreads == maxThreads)
                {
                    break;
                }
            }
        }
    }
}
