using System;

namespace CS002
{
    class Program
    {
        static void Test(A aObj)
        {
            aObj.Func01();
            aObj.Func02();
        }
        static void Main(string[] args)
        {
            A obj01 = new B();
            Test(obj01);

            A obj02 = new C();
            Test(obj02);

            Console.ReadLine();
        }
    }
}
