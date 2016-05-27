using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {

            //Simple unit tests to test the QuickSort algorith. 
            //Ideally we should use a Unit test framework with Assert statements

            //Null array
            int[] input0 = new int[] {  };
            QuickSort(input0, 0, input0.Length - 1);
            DisplayArray(input0);

            //Array with only one element
            int[] input1 = new int[] { 5 };
            QuickSort(input1, 0, input1.Length - 1);
            DisplayArray(input1);
           
            //Array with unsorted data
            int[] input2 = new int[] {5, 1, 8, 2, 9, 10, 3 };
            QuickSort(input2, 0, input2.Length - 1);
            DisplayArray(input2);

            //Array with already sorted data
            int[] input3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            QuickSort(input3, 0, input3.Length - 1);
            DisplayArray(input3);

            //Array with reverse sorted data
            int[] input4 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            QuickSort(input4, 0, input4.Length - 1);
            DisplayArray(input4);
            
            
            Console.Read();
        }

        /// <summary>
        /// Display the inputArray on the Console
        /// </summary>
        /// <param name="inputArray"> inputArray </param>
        static void DisplayArray(int[] inputArray)
        {
            foreach(int value in inputArray)
            {
                Console.Write(value + ", ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// The Recursive QuickSort function. Implement the Lomuto QuickSort algorithm
        /// from the Wikipedia entry in the following URL: https://en.wikipedia.org/wiki/Quicksort
        /// </summary>
        /// <param name="inputArray"> inputArray </param>
        /// <param name="lo"> The low index </param>
        /// <param name="hi"> The high index </param>
        static void QuickSort(int[] inputArray, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = partition(inputArray, lo, hi);
                QuickSort(inputArray, lo, p - 1);
                QuickSort(inputArray, p + 1, hi);
            }
        }

        /// <summary>
        /// Partition the array
        /// </summary>
        /// <param name="inputArray"> Input array </param>
        /// <param name="lo"> The low index </param>
        /// <param name="hi"> The high index </param>
        /// <returns></returns>
        static int partition(int[] inputArray, int lo, int hi)
        {
            //Pivot
            int pivot = inputArray[hi];
            int i = lo;
            for (int j = lo; j < hi; j++)
            {
                if (inputArray[j] <= pivot)
                {
                    //Swap inputArray[i] and inputArray[j]
                    int temp = inputArray[i];
                    inputArray[i] = inputArray[j];
                    inputArray[j] = temp;
                    i++;
                }
            }

            //Swap inputArray[i] and iputArray[hi]
            int temp1 = inputArray[i];
            inputArray[i] = inputArray[hi];
            inputArray[hi] = temp1;

            return i;
            
        }
    }
}
