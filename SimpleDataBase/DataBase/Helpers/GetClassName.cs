using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Helpers
{
    public static class GetClassName
    {
        public static string GetName(string model)
        {
            string[] subs = model.Split('.');
            return subs[subs.Length-1];
        }
        public static string GetNameFromPath(string path)
        {
            string[] subs = path.Split('-');
            return subs[subs.Length - 1];
        }
    }
}
