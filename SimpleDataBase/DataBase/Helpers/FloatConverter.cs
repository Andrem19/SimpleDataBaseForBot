using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Helpers
{
    public static class FloatConverter
    {
        public static string FloatToString(float? digit)
        {
            string fl = digit.ToString();
            if (fl.IndexOf(".", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return fl;
            }
            else
            {
                return fl + ".0";
            }
        }
    }
}
