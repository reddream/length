using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public class Caculate
    {
        public Caculate()
        { 

        }

        public string[] Output(string[] inputs)
        {
            List<string> list = new List<string>();
            UnitParsers unitParsers = new UnitParsers();
            int i = 0;
            for (; i < inputs.Length; i++)
            {
                string strInput = inputs[i];
                if (string.IsNullOrWhiteSpace(strInput))
                {
                    i++;
                    break;
                }
                IUnitParser iup = new UnitParser(strInput);
                unitParsers.Add(iup);
            }
            for (;i<inputs.Length; i++)
            {
                string strInput = inputs[i];
                if (string.IsNullOrWhiteSpace(strInput))
                    break;
                string outputStr=unitParsers.Parse(strInput);
                list.Add(outputStr);
            }
            for (int n = 0; n < list.Count; n++)
            {
                double d = EvalUtils.Eval(list[n]);
                list[n] = d.ToString("0.00") + " m";
            }
            list.Insert(0, "reddream@qq.com");
            list.Insert(1, string.Empty);
            return list.ToArray();
        }

    }
}
