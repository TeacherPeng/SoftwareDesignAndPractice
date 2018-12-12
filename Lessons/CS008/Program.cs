using System;

namespace CS008
{
    class Program
    {
        static double MyFunc(double x)
        {
            return Math.Sin(x) + Math.Cos(x);
        }
        static void Main(string[] args)
        {
            Drawer aDrawer = new Drawer(80, 25, 0, -1, 3.14*2, 1);
            int[,] aImage = aDrawer.Draw(Math.Sin);
            DrawOnConsole(aDrawer, aImage);
            int[,] aImage2 = aDrawer.Draw(MyFunc);
            DrawOnConsole(aDrawer, aImage2);
            Console.ReadLine();
        }

        private static void DrawOnConsole(Drawer aDrawer, int[,] aImage)
        {
            for (int i = 0; i < aDrawer.H; i++)
            {
                for (int j = 0; j < aDrawer.W; j++)
                {
                    Console.Write(aImage[i, j] == 1 ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
