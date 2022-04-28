using System;

namespace SortAndSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();

            for(int x = 1; x <= 6; x++)
            {
                int arraySize = 1;

                for (int y = 1; y <= x; y++)
                {
                    arraySize *= 10;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n---------------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------Array Size of {0}----------------------------------", arraySize);
                Console.WriteLine("---------------------------------------------------------------------------------------------");

                BubbleSort.Sort(ArrayGenerator.NewArray(arraySize));
                InsertionSort.Sort(ArrayGenerator.NewArray(arraySize));
                MergeSort.Sort(ArrayGenerator.NewArray(arraySize));
                QuickSort.Sort(ArrayGenerator.NewArray(arraySize));


                time.Start();
                Array.Sort(ArrayGenerator.NewArray(arraySize));
                time.Stop();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Array.Sort() in {0} milliseconds", time.ElapsedMilliseconds.ToString());
                time.Reset();
            }
        }
    }
}
