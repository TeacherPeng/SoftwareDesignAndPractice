using System;

namespace CS005
{
    class Program
    {
        delegate double CommonFunc(double x);

        static double Func01(double a) => a * a;
        static double Func02(double a) => a * a - 2 * a + 1;
        static void Test(CommonFunc aFunc)
        {
            for (double x = 0.0; x < 1.0; x += 0.2)
            {
                Console.WriteLine($"f({x}) = {aFunc(x)}");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Test(Func01);
            Test(Func02);

            Console.ReadLine();
        }
    }
}
