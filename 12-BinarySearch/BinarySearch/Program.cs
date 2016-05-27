using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple unit tests for the BinarySearch function. Ideally, these unit tests should be 
            //written in a separate test class with a Unit test framework.

            //Zero sized inputArray
            int[] input1 = new int[] { };
            Console.WriteLine(BinarySearch(input1, 1));

            //inputArray of size 1
            int[] input2 = new int[] { 1 };
            Console.WriteLine(BinarySearch(input2, 1));
            Console.WriteLine(BinarySearch(input2, 3));
            
            //inputArray of size 2
            int[] input3 = new int[] { 2, 5 };
            Console.WriteLine(BinarySearch(input3, 2));
            Console.WriteLine(BinarySearch(input3, 5));
            Console.WriteLine(BinarySearch(input3, 3));
            Console.WriteLine(BinarySearch(input3, 1));
            Console.WriteLine(BinarySearch(input3, 7));

            //inputArray of size greater than 2
            int[] input4 = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
            Console.WriteLine(BinarySearch(input4, 1));
            Console.WriteLine(BinarySearch(input4, 9));
            Console.WriteLine(BinarySearch(input4, 4));
            Console.WriteLine(BinarySearch(input4, 25));
            Console.WriteLine(BinarySearch(input4, 21));
            Console.WriteLine(BinarySearch(input4, -3));

            Console.Read();
        }

        /// <summary>
        /// This functions returns the location of the numToBeFound in the inputArray using Binary Search Algorithm
        /// If the numToBeFound does not exist in the inputArray, -1 will be returned.
        /// </summary>
        /// <param name="inputArray"> The input Array of integers </param>
        /// <param name="numToBeFound"> The number to be found in the inputArray </param>
        /// <returns> Location of the numToBeFound if it exists, -1 if it does not exist </returns>
        static int BinarySearch(int[] inputArray, int numToBeFound)
        {
            //Zero sized array
            if (inputArray.Length == 0)
                return -1;
            
            int left, right, middle;
            
            left = 0;
            right = inputArray.Length - 1;
            
            //Loop till you either find the number in the array or you complete the binary search.
            while (true)
            {
                middle = (left + right) / 2;

                //If the middle element in the inputArray matches, just return the index of the middle number
                if (numToBeFound == inputArray[middle])
                    return middle;
                
                //We have finished the binary search. Stopping condition to prevent infinite loop
                if (left == middle)
                {
                    //Edge case for right-most element in the inputArray
                    //because the middle will never assume the value of the right-most element in the inputArray
                    if (numToBeFound == inputArray[right])
                        return right;
                    else
                        return -1;
                }
                
                if (numToBeFound < inputArray[middle])
                {
                    //Search left half
                    right = middle;
                }
                else
                {
                    //Search right half
                    left = middle;
                }                
            }

        }


    }
}
