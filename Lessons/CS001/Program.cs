using System;

namespace CS001
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = new int[10];
            for (int i = 0; i < a1.Length; i++)
                a1[i] = i;
            foreach (int x in a1) Console.Write($"{x}, ");
            Console.WriteLine();

            int[,] a2 = new int[5, 6];
            for (int i = 0; i < a2.GetLength(0); i++)
                for (int j = 0; j < a2.GetLength(1); j++)
                    a2[i, j] = i + j;
            
            int[][] a3 = new int[3][];
            a3[0] = new int[5];
            a3[1] = new int[6];
            a3[2] = new int[3];
            a3[0][1] = 1;

            Console.ReadLine();
        }
    }
}
