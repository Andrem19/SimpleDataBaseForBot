using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.JsonToCSharp
{
    public class Universal<T1, T2>
    {
        public string Name { get; set; }
        public Dictionary<T1, T2> Values { get; set; }
    }
}
