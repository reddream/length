using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public class WordDictionary
    {
        private readonly static Dictionary<string, string> irregulars = new Dictionary<string, string>();
        private WordDictionary()
        { 
        
        }
        
        static WordDictionary()
        {
           string dictionary= ConfigurationManager.AppSettings["dictionary"];
           string[] arrayDic = dictionary.Split(new char[] { ',' });
           foreach (string s in arrayDic)
           {
               string[] arrayUnits = s.Split(new char[] { '|'});
               irregulars[arrayUnits[0]] = arrayUnits[1];
           }
        }


        public static string Plural(string name)
        {
            name = name.Trim().ToLower();
            Regex plural1 = new Regex("(?<keep>[^aeiou])y$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)$");
            Regex plural3 = new Regex("(?<keep>[sxzh])$");
            Regex plural4 = new Regex("(?<keep>[^sxzhy])$");
            if (irregulars.ContainsKey(name))
            {
                return irregulars[name];
            }
            if (plural1.IsMatch(name))
                return plural1.Replace(name, "${keep}ies");
            else if (plural2.IsMatch(name))
                return plural2.Replace(name, "${keep}s");
            else if (plural3.IsMatch(name))
                return plural3.Replace(name, "${keep}es");
            else if (plural4.IsMatch(name))
                return plural4.Replace(name, "${keep}s");
            return name;
        }
    }
}
