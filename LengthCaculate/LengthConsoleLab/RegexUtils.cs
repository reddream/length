using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public class RegexUtils
    {
       public readonly static Regex InputRegex = new Regex(@"(?<otherunit>1 \w+)|(?<meters>[0-9]*\.?[0-9]+ m)|(?<nn>[0-9]d* m)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    }
}
