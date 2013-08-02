using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            string str = "1 mile = 1609.344 m  55 m";
            string pattern = @"(?<otherunit>1 \w+)|(?<meters>[0-9]*\.?[0-9]+ m)|(?<nn>[0-9]d* m)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled|RegexOptions.IgnoreCase);
            var matches = regex.Matches(str);
            Console.WriteLine(matches[0].Groups[0].Value);
            Console.WriteLine(matches[1].Groups[0].Value);
            Console.WriteLine(matches[2].Groups[0].Value);
            */
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
            string[] lines = File.ReadAllLines(filename);
            Caculate c = new Caculate();
            string[] arrayResult = c.Output(lines);
            string outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            File.WriteAllLines(outputFile, arrayResult);
            Console.ReadLine();
        }
    }
}
