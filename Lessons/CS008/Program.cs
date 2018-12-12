using System;

namespace CS008
{
    class Program
    {
        static double MyFunc(double x)
        {
            return Math.Cos(x);
        }
        static void Main(string[] args)
        {
            int[,] aImage = new int[25, 80];
            Drawer aDrawer = new Drawer(0, -1, 3.14*2, 1);
            aDrawer.Draw(aImage, Math.Sin);
            DrawOnConsole(aImage);
            aDrawer.Draw(aImage, MyFunc);
            DrawOnConsole(aImage);
            Console.ReadLine();
        }

        private static void DrawOnConsole(int[,] aImage)
        {
            int W = aImage.GetLength(1);
            int H = aImage.GetLength(0);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    Console.Write(aImage[i, j] == 1 ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
