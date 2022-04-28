using System;
using System.Collections.Generic;
using System.Text;

namespace SortAndSearch
{
    public static class InsertionSort
    {
        public static void Sort(int[] arr)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            Console.ForegroundColor = ConsoleColor.White;
            time.Start();

            for (int x = 1; x < arr.Length; ++x)
            {
                int value = arr[x];
                int currentIndex = x - 1;

                while(currentIndex >= 0 && arr[currentIndex] > value)
                {
                    arr[currentIndex + 1] = arr[currentIndex];
                    currentIndex -= 1;
                }
                arr[currentIndex + 1] = value;

                if(time.ElapsedMilliseconds > 60000)
                {
                    Console.WriteLine("Insertion Sort has timed out");
                    return;
                }
            }

            time.Stop();
            Console.WriteLine("Insertion Sort in {0} milliseconds", time.ElapsedMilliseconds.ToString());
        }
    }
}
