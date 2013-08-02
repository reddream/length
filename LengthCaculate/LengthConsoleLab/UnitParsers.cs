using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public class UnitParsers:List<IUnitParser>
    {
        public string Parse(string strInput)
        {
            foreach (var p in this)
            {
              strInput=p.ConvertToMetersWithNoUnitFix(strInput);
            }
            return strInput;
        }
    }
}
