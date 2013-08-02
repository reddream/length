using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public class UnitParser:IUnitParser
    {
        private string name;
        private double meters;
        private List<Regex> regexes;

        public UnitParser(string input)
        {
            name = input;
            var matches = RegexUtils.InputRegex.Matches(input);
            ParseUnit(matches);
            ParseMeters(matches);
        }

        private void ParseMeters(MatchCollection matches)
        {
            string metersString = matches[1].Groups[0].Value.Trim();
            string[] arrayMeters = metersString.Split(new char[] { ' ' });
            string meterValue = arrayMeters[0];
            meters = double.Parse(meterValue);
        }

        private void ParseUnit(MatchCollection matches)
        {
            string originalUnit = matches[0].Groups[0].Value;
            originalUnit = originalUnit.Trim();
            string unit = originalUnit.Split(new char[] { ' ' })[1];
            regexes = new List<Regex>();
            string pname = WordDictionary.Plural(unit);
            GenerateRegex(pname,regexes);
            GenerateRegex(unit,regexes);
        }

        private void GenerateRegex(string name,List<Regex> list)
        { 
            string pattern=@"(?<meters>[0-9]*\.?[0-9]+ "+name+")";
            list.Add(new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));
            pattern = @"(?<nn>[0-9]d* "+name+")";
            list.Add(new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));
        }


        public string Name
        {
            get { return name; }
        }

        public string ConvertToMetersWithNoUnitFix(string str)
        {
            string content = str;
            foreach (var r in regexes)
            {
               var matches = r.Matches(content);
               foreach (Match m in matches)
               {
                   string groupValue = m.Groups[0].Value;
                   groupValue = groupValue.Trim();
                   string[] array = groupValue.Split(new char[] { ' ' });
                   double d = double.Parse(array[0]);
                   d = d * meters;
                   content = content.Replace(groupValue, d.ToString());
               } 
            }
            return content;
        }
    }
}
