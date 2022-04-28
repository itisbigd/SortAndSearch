using System;
using System.Collections.Generic;
using System.Text;

namespace SortAndSearch
{
    public static class QuickSort
    {
        static int count = 0;
        public static void Sort(int[] arr)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            Sort(arr, 0, arr.Length - 1);
            time.Stop();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Quick Sort finished in {0} milliseconds and had {1} recursion(s)", time.ElapsedMilliseconds.ToString(), count);
        }

        static void Sort(int[] arr, int low, int high)
        {
            count++;
            if(low < high)
            {
                int partitioningIndex = Partition(arr, low, high);

                Sort(arr, low, partitioningIndex - 1);
                Sort(arr, partitioningIndex + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = low - 1;

            for(int x = low; x <= high - 1; x++)
            {
                if(arr[x] < pivot)
                {
                    i++;
                    Swap(arr, i, x);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
