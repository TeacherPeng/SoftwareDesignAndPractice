using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexLesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex aRegex = new Regex(@"\bc[aeiou]+t\b");
            string aText;
            aText = Console.ReadLine();

            // 检测
            if (aRegex.IsMatch(aText))
                Console.WriteLine("检测通过！");
            else
                Console.WriteLine("检测不通过！");

            // 整体提取
            Match aMatch = aRegex.Match(aText);
            if (aMatch.Success)
                Console.WriteLine($"匹配结果：{aMatch.Value}");

            // 局部提取
            foreach (Group aGroup in aMatch.Groups)
            {
                Console.WriteLine($"Group: {aGroup.Value}");
            }

            // 
        }
    }
}
