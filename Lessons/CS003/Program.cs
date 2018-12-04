using System;

namespace CS003
{
    class Program
    {
        static void Test(ISeriable aObj)
        {
            aObj.Read();
            aObj.Write();
        }
        static void Main(string[] args)
        {
            // ISeriable aObj = new A();
            A aObj = new A();
            Test(aObj);

            Console.ReadLine();
        }
    }
}
