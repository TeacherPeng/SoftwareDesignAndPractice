using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq;

namespace Adodb01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demo01;Integrated Security=True;";
                // 查找记录
                using (MyDataDataContext aDataContext= new MyDataDataContext(ConnectionString))
                {
                    var aQuery =
                        from r in aDataContext.PersonInfo
                        where r.Name == "李四"
                        select r;
                    foreach (var r in aQuery)
                    {
                        Console.WriteLine(r.Name);
                        r.Department = "销售";
                    }
                    var aQuery2 =
                        from r in aDataContext.PersonInfo
                        where r.Name == "王五"
                        select r;
                    aDataContext.PersonInfo.DeleteAllOnSubmit(aQuery2);

                    aDataContext.SubmitChanges();
                    Console.WriteLine("Update over.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
