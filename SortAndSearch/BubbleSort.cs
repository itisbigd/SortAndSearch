using System;
using System.Collections.Generic;
using System.Text;

namespace SortAndSearch
{
    public static class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            Console.ForegroundColor = ConsoleColor.White;
            time.Start();

            while (true)
            {
                bool wasNumberChanged = false;

                for(int x = 1; x < arr.Length; x++)
                {
                    if(arr[x] < arr[x - 1])
                    {
                        int temp = arr[x];
                        arr[x] = arr[x - 1];
                        arr[x - 1] = temp;
                        wasNumberChanged = true;
                    }
                }

                if (!wasNumberChanged)
                {
                    break;
                }

                if(time.ElapsedMilliseconds > 60000)
                {
                    Console.WriteLine("Bubblesort has timed out");
                    return;
                }
            }

            time.Stop();
            Console.WriteLine("Bubblesort in {0} milliseconds", time.ElapsedMilliseconds.ToString());
        }
    }
}
