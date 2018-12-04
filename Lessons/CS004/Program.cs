using System;

namespace CS004
{
    class Program
    {
        static string Test()
        {
            System.IO.StreamReader aStream = new System.IO.StreamReader(@"X:\nothing.noexist");
            string aText = aStream.ReadLine();
            aStream.Close();
            return aText;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("试图打开一个不存在的文件……");
                string aResult = Test();
                Console.WriteLine(aResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("执行完毕……");
            }
            Console.ReadLine();
        }
    }
}
