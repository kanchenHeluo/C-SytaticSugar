using System;
/*
 Lambda: 一种用于创建委托或者表达式目录树的匿名函数
 形式： (参数)=> 语句 or {块}
 大类： 同步/异步lambda
*/


namespace LambdaExample
{

    public static class Test
    {
        

        delegate int del1(int a);

        delegate bool del2(int a);

        delegate bool del3();

        public static void testMetric1()
        {
            // Lambda used for delegate
            Func<int, bool> myFunc = x => x == 5;
            del1 myDelegate1 = x => x*x;
            del2 myDelegate2 = x => x == 5;

            Console.WriteLine(myDelegate1(2));
            Console.WriteLine(myDelegate2(5));
            Console.WriteLine(myFunc(5));

            // Lambda used for Expression<Func> (linq operators accept Expression<Func<TSource>>)
            // TO BE Updated

        }

        public static void testMetric2(int b)
        {
            int a = 3;
            del3 myDelegate3 = () => a == b;
            Console.WriteLine(myDelegate3());
            a = 4;
            Console.WriteLine(myDelegate3());
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Examples used for delegates:");
            Test.testMetric1();

            Console.WriteLine("Examples showed lambda variable:");
            Test.testMetric2(4);
            Console.ReadKey();
        }
    }
}
