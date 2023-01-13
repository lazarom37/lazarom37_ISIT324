using System;

namespace ISIT324_Homework1
{
    class Program
    {
        static void Main(string[] args)
        {

            /**
            * Find last index of element
            *
            * @param x array to search
            * @param y value to look for
            * @return last index of y in x; -1 if absent
            * @throw NullPointerException if x is null
*/
            int findLast(int[] x, int y)
            {
                for (int i = x.Length-1; i >= 0; i--) //FIXED: changed operator from = to >=
                {
                    if (x[i] == y)
                    {
                        return i;
                    }
                    Console.WriteLine(x[i] + " checked");
                }
                return -1;
            }
            // test: x = [2, 3, 5]; y = 2; Expected = -1

            int[] x = {2, 3, 5};
            int y = 0;
            Console.Write("END RESULT: " + findLast(x, y));

        }
    }
}
