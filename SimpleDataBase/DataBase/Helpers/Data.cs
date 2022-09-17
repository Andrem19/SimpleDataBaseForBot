using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Helpers
{
    public static class Data
    {
        public static string Convert(string data)
        {
            string[] oldData = data.Split(' ');
            string[] newData = oldData[0].Split('/');
            StringBuilder sb = new StringBuilder();
            sb.Append($"{newData[2]}");
            sb.Append($"-");
            sb.Append($"{newData[1]}");
            sb.Append($"-");
            sb.Append($"{newData[0]}");
            sb.Append($"T");
            sb.Append($"{oldData[1]}");
            return sb.ToString();
        }
    }
}
