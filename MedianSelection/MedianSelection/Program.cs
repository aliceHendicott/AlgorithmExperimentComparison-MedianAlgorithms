using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianSelection
{
    class Program
    {

        static void Main(string[] args){
            //declare the array to be tested
            int[] A = {8, 22, 1, 4, 6, 16, 13, 25, 9 };

            // output  the  array  and algorithm type to the  screen
            Console.WriteLine("The array inputted is: [{0}]", string.Join(", ", A));

            //Calculate  the  median  using  the  algorithm  and  then  output  this to the screen
            int m = Median(A);
            Console.WriteLine("The  median  is: " + m);

            Console.ReadLine();
        }


        /// <summary>
        /// Returns the median value in a given array that is not necessarily sorted.
        /// </summary>
        /// <param name="A">The array inputted</param>
        /// <returns>The median found for the array A</returns>
        static int Median(int[] A){
            if (A.Length == 1){
                return A[0];
            }
            else{
                    return Select(A, 0, Convert.ToInt32(Math.Floor(A.Length / 2.0)), A.Length - 1);
            }   
        }

        /// <summary>
        /// Returns the value at index m in array slice A[l..h], if the slice
        /// were sorted into nondecreasing order.
        /// </summary>
        /// <param name="A">The array in which the slice is taken from</param>
        /// <param name="l">The started index of the slice</param>
        /// <param name="m">The index of the value we are trying to find</param>
        /// <param name="h">The ending index of the slice</param>
        /// <returns>Recursive function that will continue to call itself until
        /// the value at m is found at which point it will return this value.</returns>
        static int Select(int[] A, int l, int m, int h){
            int pos = Partition(A, l, h);
            if(pos == m){
                return A[pos];
            }
            if(pos > m){
                return Select(A, l, m, pos - 1);
            }
            if(pos < m){
                return Select(A, pos + 1, m, h);
            }
            return -1;
        }

        /// <summary>
        /// Partitions array slice A[1...h] by moving element A[l] to the position
        /// it would have if the array slice was sorted, and by moving all values
        /// in the slice smaller than A[l] to earlier positions.
        /// </summary>
        /// <returns>The index at which the 'pivot' element formerly located at A[l]
        /// is placed.</returns>
        /// <param name="A">The array</param>
        /// <param name="l">The started index of the slice</param>
        /// <param name="h">The ending index of the slice</param>
        static int Partition(int [] A, int l, int h){
            int pivotval = A[l]; //Choose first value in slice as pivot value
            int pivotloc = l; //Location to insert pivot value
            for(int j = l + 1; j <= h; j++){
                if(A[j] < pivotval){
                    pivotloc += 1;
                    swap(A, pivotloc, j); //Swap elements around pivot
                }
            }
            swap(A, l, pivotloc); //Put pivot element in place
            return pivotloc;
        }

        /// <summary>
        /// Swaps two elements in an array
        /// </summary>
        /// <param name="A">The array</param>
        /// <param name="index1">The index of the first value to be swapped</param>
        /// <param name="index2">The index of the second value to be swapped</param>
        static void swap(int[] A, int index1, int index2){
            int firstValue = A[index1];
            A[index1] = A[index2];
            A[index2] = firstValue; 
        }
    }
}
