using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql001
{
    class Program
    {
        const string ConnectionString = @"Data Source=localhost\sqlexpress; Initial Catalog=MyRegex; Integrated Security=true;";
        static string PasswordEncode(string aPassword)
        {
            return aPassword + aPassword;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("User Id:");
                string aUserId = Console.ReadLine();
                Console.WriteLine("Password: ");
                string aPassword = Console.ReadLine();
                aPassword = PasswordEncode(aPassword);

                using (RegexDataContext aDataContext = new RegexDataContext(ConnectionString))
                {
                    var aUser = (from r in aDataContext.User where r.UserId == aUserId select r).FirstOrDefault();
                    if (aUser == null)
                    {
                        throw new ApplicationException("不存在该用户！");
                    }
                    else if (aUser.Password != aPassword)
                    {
                        throw new ApplicationException("错误的登录密码!");
                    }
                    Console.WriteLine("登录成功！");

                    // 删除记录
                    RegularExpression aRegex = (from r in aDataContext.RegularExpression where r.Memo != "" select r).FirstOrDefault();
                    aDataContext.RegularExpression.DeleteOnSubmit(aRegex);
                    var aQuery = from r in aDataContext.RegularExpression where r.Memo == "" select r;
                    aDataContext.RegularExpression.DeleteAllOnSubmit(aQuery);

                    // 修改记录
                    User aUserWillModified = (from r in aDataContext.User where r.UserId == "user01" select r).FirstOrDefault();
                    aUserWillModified.Password = PasswordEncode("newpassword");

                    // 根据关系的复合查询
                    RegularExpression aRegEx = (from r in aDataContext.RegularExpression where r.Memo == "test" select r).FirstOrDefault();
                    if (aRegex != null)
                    {
                        Console.WriteLine($"该记录是由{aRegex.User.UserId}创建的！");
                    }

                    foreach(RegularExpression aRegex0 in aUser.RegularExpression)
                    {
                        Console.WriteLine($"[{aUser.UserId} 创建了 [{aRegex.Expression}].");
                    }
                    aDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press RETURN to exit...");
            Console.ReadLine();
        }
    }
}
