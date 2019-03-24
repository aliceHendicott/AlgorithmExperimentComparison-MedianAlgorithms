using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceMedian
{
    class Program
    {
        static void Main(string[] args) {

            //define the array A according to the case (the following is case 1)
            int[] A = { 6, 3, 7, 1, 10, 8, 5, 4 };

            //output the array to the screen
            Console.WriteLine("The array inputted is: [{0}]", string.Join(", ", A));

            //Calculate the median using the algorithm and then output this to the screen
            int m = BruteForceMedian(A);
            Console.WriteLine("The median is: " + m);
            Console.ReadLine();
        }


        /// <summary>
        /// Returns the median value in a given array of n numbers. 
        /// This is the kth element, where k = [n/2], if the array was sorted.
        /// </summary>
        /// <param name="A">The array</param>
        /// <returns>The median</returns>
        static int BruteForceMedian(int [] A){
            //define the position of the median. k - |n/2|
            double k = Math.Ceiling((A.Length)/ 2.0);

            //go through each element in the array
            for (int i = 0; i <= A.Length - 1; i++){
                int numsmaller = 0; //How many elements are smaller than A[i]
                int numequal = 0; //How many elements are equal ot A[i]

                //compare to each other value in the array including itself
                for(int j = 0; j <= A.Length - 1; j++){

                    //if the  value  at  position i is  greater  the  that at  position j,
                    // increase  numsmaller  by 1
                    if (A[j] < A[i]){                       
                        numsmaller += 1;
                    }
                    else {
                        //if the  value  at  positions i and j are  equal (will  always  occur
                        //at least  once  because i is  compared  to j when i=j), increase
                        // numequals
                        if (A[j] == A[i]) {
                            numequal += 1;
                        }
                    }
                }
                // return  the  value  at i if there  are  less  than k numbers  smaller , and
                //if  numsmaller+numequal  is  greater  than or equal  to k
                if(numsmaller < k && k <= (numsmaller + numequal))
                    {
                    return A[i];
                }
            }
            //this  has  been  added  to  ensure  all  coden  paths  return a value , however  this
            //will  never  be  reached
            return -1;
        }
    }
}
