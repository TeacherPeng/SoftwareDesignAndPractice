using System;
using System.Collections.Generic;

namespace CS007
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> aDatas = new List<int>();

            Random aRandom = new Random();
            for (int i = 0; i < 100; i++)
            {
                aDatas.Add(aRandom.Next(10000));
            }

            foreach (int x in aDatas) Console.Write($"{x}, ");
            Console.WriteLine();
            Console.WriteLine();

            aDatas.Sort();
            foreach (int x in aDatas) Console.Write($"{x}, ");
            Console.WriteLine();
            Console.WriteLine();

            Stack<int> aStack = new Stack<int>();
            foreach (int x in aDatas) aStack.Push(x);
            while (aStack.Count > 0)
            {
                Console.Write($"{aStack.Pop()}, ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
