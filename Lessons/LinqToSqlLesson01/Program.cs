using System;
using System.Linq;

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

                    // 读取数据表内容
                    var aContacts = from r in aDataContext.Contact select r;
                    foreach (Contact aContact in aContacts)
                    {
                        Console.WriteLine($"{aContact.Name} : {aContact.Mobile}");
                    }

                    Console.WriteLine("插入新记录……");
                    Contact aNewContact = new Contact { Name = "张三", Mobile = "13000000000", Memo = "Nothing" };
                    aDataContext.Contact.InsertOnSubmit(aNewContact);

                    Console.WriteLine("删除记录……");
                    Contact aExistContact = (from r in aDataContext.Contact where r.Name == "李四" select r).FirstOrDefault();
                    if (aExistContact != null)
                    {
                        aDataContext.Contact.DeleteOnSubmit(aExistContact);
                    }

                    Console.WriteLine("修改记录……");
                    Contact aOtherContact = (from r in aDataContext.Contact where r.Name == "王五" select r).FirstOrDefault();
                    if (aOtherContact != null)
                    {
                        aOtherContact.Memo = "本记录要被修改！";
                    }

                    Console.WriteLine("提交数据……");
                    aDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("按回车键退出……");
            Console.ReadLine();
        }
    }
}
