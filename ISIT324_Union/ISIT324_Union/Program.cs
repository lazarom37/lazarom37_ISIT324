using System;
using System.Collections;

namespace ISIT324_Union
{
    class Program
    {

        static void Main(string[] args)
        {
            ArrayList sample1 = new ArrayList() { 1, 2, 3 };
            ArrayList sample2 = new ArrayList() { 4, 5, 6 };
            foreach (var item in sample1)
            {
                Console.WriteLine("sample1: " + item);
            }
            Console.WriteLine();
            foreach (var item in sample2)
            {
                Console.WriteLine("sample2: " + item);
            }
            Console.WriteLine();
            Console.WriteLine("Here they are together: ");

            foreach (var item in Union(sample1, sample2))
            {
                Console.WriteLine("final: " + item);
            }
        }

        public static ArrayList Union(ArrayList a, ArrayList b)
        {
            //return a list of objects from two arrayLists
            ArrayList final = new ArrayList();
            foreach (var item in a)
            {
                final.Add(item);
            }
            foreach (var item in b)
            {
                final.Add(item);
            }
            return final;
        }
    }
}