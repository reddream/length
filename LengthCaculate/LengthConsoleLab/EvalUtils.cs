using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthConsoleLab
{
    public static class EvalUtils
    {
        private readonly static string operators = "";
        public static double Eval(string strInput)
        {
            double d = 0.0;
            if (double.TryParse(strInput, out d))
                return d;
            else
            {
                DataTable table = new DataTable();
                DataColumn expColumn = new DataColumn();
                expColumn.Expression = strInput;
                table.Columns.Add(expColumn);
                DataRow dr = table.NewRow();
                table.Rows.Add(dr);
                return double.Parse(dr[expColumn].ToString());
            }
        }
    }
}
