using System;
using System.Collections.Generic;
using System.Text;

namespace SortAndSearch
{
    public static class MergeSort
    {
        private static int count;
        public static void Sort(int[] arr)
        {
            count = 0;
            Sort(arr, 0, arr.Length - 1);
        }

        static void Sort(int[] arr, int left, int right)
        {
            bool isRoot = false;
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();

            if(count == 0)
            {
                isRoot = true;
                time.Start();
            }

            count++;

            if(left < right)
            {
                //Find the middle point
                int middle = left + (right - left) / 2;

                //Sort both halves individually
                Sort(arr, left, middle);
                Sort(arr, middle + 1, right);

                //Merge sorted halves
                Merge(arr, left, middle, right);
            }

            if (isRoot)
            {
                time.Stop();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Merge Sort finished in {0} milliseconds and had {1} recursion(s)", time.ElapsedMilliseconds.ToString(), count);
            }
        }

        static void Merge(int[] arr, int left, int middle, int right)
        {
            //Find sizes of two subarrays to be merged
            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            //Create temp arrays
            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];
            int i, j;

            //copy data to temp arrays
            for (i = 0; i < leftSize; ++i)
                leftArray[i] = arr[left + i];
            for (j = 0; j < rightSize; ++j)
                rightArray[j] = arr[middle + 1 + j];

            //merge temp arrays

            i = 0;
            j = 0;

            int k = left;
            while(i < leftSize && j < rightSize)
            {
                if(leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while(i < leftSize)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }

            while(j < rightSize)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
