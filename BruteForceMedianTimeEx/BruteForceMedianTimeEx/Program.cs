using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BruteForceMedianTimeEx
{
    class Program
    {

            static void Main(string[] args){
                // create a variable to represent the number of tests to average for each size n
                int numTestsPerSize = 100;

                // set up a Stopwatch variable
                Stopwatch sw = new Stopwatch();
                    
                //go through each different input size
                for (int size = 5000; size <= 20000; size+=500){
                    double averageMilliSecs = 0;
                    long totalMilliSecs = 0;

                    //do numTestsPerSize tests for each size
                    for (int i = 1; i < numTestsPerSize; i++){
                        long milliSecs = 0;

                        //Generate random array of size
                        int[] A = GenerateArray(size);

                        //Start stopwatch and run Algorithm
                        sw.Start();
                        BruteForceMedianTimeEx(A);

                        //Stop stopwatch
                        sw.Stop();

                        milliSecs = sw.ElapsedMilliseconds;
                        totalMilliSecs = totalMilliSecs + milliSecs;
                    }   
                    //calculate the average milliseconds for current input size
                    averageMilliSecs = totalMilliSecs * 1.0 / numTestsPerSize;
                    Console.WriteLine(averageMilliSecs);
                }
                Console.ReadLine();
            }

            /// <summary>
            /// Returns the median value in a given array of n numbers. 
            /// This is the kth element, where k = [n/2], if the array was sorted.
            /// </summary>
            /// <param name=""></param>
            /// <returns></returns>
            static int BruteForceMedianTimeEx(int[] A)
            {
                double k = Math.Ceiling(A.Length / 2.0);
                for (int i = 0; i <= A.Length - 1; i++)
                {
                    int numsmaller = 0; //How many elements are smaller than A[i]
                    int numequal = 0; //How many elements are equal ot A[i]
                    for (int j = 0; j <= A.Length - 1; j++)
                    {
                    if (A[j] < A[i]) {
                        numsmaller += 1;
                    } else {
                        if (A[j] == A[i]) {
                            numequal += 1;
                        }
                    }
                    }
                    if (numsmaller < k && k <= (numsmaller + numequal))
                    {
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
            static int[] GenerateArray(int size)
            {
                int[] A = new int[size];
                Random rnd = new Random();
                for (int i = 0; i <= size - 1; i++)
                {
                    A[i] = rnd.Next(100000);
                }
                return A;
            }

        
    }
}
