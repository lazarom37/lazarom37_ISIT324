using System;

namespace ISIT324_Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { -1, 0, 1 };
            Console.WriteLine(countPositive(input));
        }
        public static int countPositive(int[] x)
        {
            int count = 0;
            for (int i = 0; i < x.Length-1; i++)
            {
                if (x[i] >= 0)
                {
                    count++;
                }
            }
            return count;
        }
        // original test: x = [-4, 2, 0, 2]; Expected = 2 (this works now)
        // new test that works: x = [-1, 0, 1]; Expected = 1
    }
}
