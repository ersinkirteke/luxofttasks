using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Big O notation : O(n)
             * n is the numbert of items in the array 
             */

            //[1,2,3,1]
            //[2,7,9,3,1]
            //[5,1,2,5]

            MaxSum maxSum = new MaxSum();

            Console.WriteLine(maxSum.FindSum(new int[] { 1, 2, 3, 1 }));
            Console.WriteLine(maxSum.FindSum(new int[] { 2, 7, 9, 3, 1 }));
            Console.WriteLine(maxSum.FindSum(new int[] { 5, 1, 2, 5 }));

            Console.ReadLine();

        }
    }

    public class MaxSum
    {
        public int FindSum(int[] arr)
        {
            int length = arr.Length;
            int incl = arr[0];
            int excl = 0, temp;

            for (int i = 1; i < length; i++)
            {
                temp = incl;
                incl = Math.Max(incl, excl + arr[i]);
                excl = temp;
            }

            return incl;
        }
    }
}
