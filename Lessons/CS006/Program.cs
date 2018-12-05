using System;

namespace CS006
{
    class Program
    {
        static void Main(string[] args)
        {
            MyObject aObj = new MyObject();
            aObj.ProgressChanged += OnProgressChanged;
            aObj.DoWork();

            Console.WriteLine();
            Console.WriteLine("计算完毕，按回车键结束……");
            Console.ReadLine();
        }

        private static void OnProgressChanged(object sender, int percent)
        {
            Console.Write($"{percent}%\r");
        }
    }
}
