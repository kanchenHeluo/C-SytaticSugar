using System;
using System.Collections.Generic;

namespace DelegateExample
{
    delegate bool moreOrLessDelegate(int item);
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1: normal delegate demo
            moreOrLessDelegate comp = new moreOrLessDelegate(More);
            var arr = new List<int>() {1,2,3,4,5,6,7,8,9,10};
            Print(arr, comp);

            arr.ForEach(a=>Console.WriteLine(a));
            Console.ReadKey();
        }

        public static bool More(int a)
        {
            return a > 5;
        }

        public static void Print(List<int> arr, moreOrLessDelegate del )
        {
            foreach (var item in arr)
            {
                if (del(item))
                {
                    Console.Write(item+"\t");
                }
            }
            Console.WriteLine();
        }
    }
}
