using System;

namespace LinqToSqlLesson01
{
    class Program
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=linqlesson01;Integrated Security=true;";
        static void Main(string[] args)
        {
            try
            {
                // 连接数据库引擎
                using (MyLesson01DataContext aDataContext = new MyLesson01DataContext(ConnectionString))
                {
                    if (!aDataContext.DatabaseExists())
                    {
                        aDataContext.CreateDatabase();
                        Console.WriteLine("数据库已经创建！");
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("按回车键退出……");
            Console.ReadLine();
        }
    }
}
