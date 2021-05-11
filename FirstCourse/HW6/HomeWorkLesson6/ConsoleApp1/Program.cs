using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = File.ReadAllText("royallib.ru.txt", Encoding.UTF8)
                        .ToLower()
                        .Split(
                new char[] { '.', ',', ' ', ';',
                             ':', '!', '?', '-',
                             '"','\n','\r','\t',
                             '<','>','[',']','(',')',
                             '>','–'
            
                }, StringSplitOptions.RemoveEmptyEntries)
                        .GroupBy(KeySelector)
                        .OrderBy(Selector);
            
            
            var len = s.Count();
            Console.WriteLine(len);
            foreach (var item in s.Where(e => e.Count() > 100))
            {
                Console.WriteLine($"{Math.Round((((double)item.Count()) / len * 100), 2),10}% : {item.Key} ");
            }
        }

        private static int Selector(IGrouping<string, string> e)
        {
            return e.Count();
        }

        private static string KeySelector(string e)
        {
            return e;
        }
    }
}