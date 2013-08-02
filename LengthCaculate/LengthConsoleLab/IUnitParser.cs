using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public interface IUnitParser
    { 
        string Name { get; }
        string ConvertToMetersWithNoUnitFix(string str); 
    } 
}
