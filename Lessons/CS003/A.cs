using System;

namespace CS003
{
    class A : ISeriable
    {
        public string Value { get; set; }

        public void Read()
        {
            Value = Console.ReadLine();
        }

        public void Write()
        {
            Console.WriteLine($"Value is [{Value}].");
        }
    }
}
