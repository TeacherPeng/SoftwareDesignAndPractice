using System;

namespace CS000
{
    class Program
    {
        static void Main(string[] args)
        {
            MyObject aObject = new MyObject { X = 1, Y = 2, Z = 3 };
            aObject.Print();

            aObject.X = -2;
            aObject.Print();

            aObject.Y = 5;
            Console.WriteLine(aObject);

            Console.ReadLine();
        }
    }
}
