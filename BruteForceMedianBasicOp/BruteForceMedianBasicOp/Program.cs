using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceMedianBasicOp {
    class Program {
        //declare our basic operation counter as a global variable
        public static int basicOpCounter;

        static void Main(string[] args) {
            //declare the number of tests to be performed
            int numTests = 100;

            //go through each size of array in our test data
            for (int size = 5000; size <= 20000; size += 500) {
                double avgBasicOp = 0;
                Int64 totalBasicOp = 0;

                //do numTests tests for each input size
                for (int i = 1; i <= numTests; i++) {
                    basicOpCounter = 0;

                    //generate array and run algorithm
                    int[] A = GenerateArray(size);
                    BruteForceMedianBasicOp(A);

                    //increase total basic operation
                    totalBasicOp += basicOpCounter;
                }

                //calculate average basic operation for the current array size
                avgBasicOp = (totalBasicOp / numTests);
                Console.WriteLine(avgBasicOp);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Returns the median value in a given array of n numbers. 
        /// This is the kth element, where k = [n/2], if the array was sorted.
        /// </summary>
        /// <param name="A">The array</param>
        /// <returns></returns>
        static int BruteForceMedianBasicOp(int[] A) {
            double k = Math.Ceiling(A.Length / 2.0);
            for (int i = 0; i <= A.Length - 1; i++) {
                int numsmaller = 0;
                int numequal = 0;
                for (int j = 0; j <= A.Length - 1; j++) {
                    basicOpCounter += 1; //increment basic operations counter
                    if (A[j] < A[i]) {
                        numsmaller += 1;
                    } else {
                        if (A[j] == A[i]) {
                            numequal += 1;
                        }
                    }
                }
                if (numsmaller < k && k <= (numsmaller + numequal)) {
                    return A[i];
                }
            }
            return -1;
        }

        ///<summary>
        /// generate an array
        /// </summary>
        /// <param name="A">the size of the array to be generated</param>
        /// <returns>a random array</returns>
        static int[] GenerateArray(int size) {
            int[] A = new int[size];
            Random rnd = new Random();
            for (int i = 0; i <= size - 1; i++) {
                A[i] = rnd.Next(100000);
            }
            return A;
        }

    }
}
