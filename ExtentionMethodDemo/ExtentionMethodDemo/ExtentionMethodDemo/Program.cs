using System;

namespace ExtentionMethodDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            string test = "  hello world 1 2 3 ";
            Console.WriteLine("result:"+test.TrimAll());
            Console.WriteLine(test.IsNullOrEmpty());
            Console.ReadKey();
        }
        
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
