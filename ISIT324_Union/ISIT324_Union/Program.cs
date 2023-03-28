using System;
using System.Collections;

namespace ISIT324_Union
{
    class Program
    {

        static void Main(string[] args)
        {
            ArrayList sample1 = new ArrayList() { true, true, true };
            ArrayList sample2 = new ArrayList() { false, false, false};
            Console.WriteLine("sample1: ");
            foreach (var item in sample1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("sample2: ");
            foreach (var item in sample2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here they are together: ");

            foreach (var item in Union(sample1, sample2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
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