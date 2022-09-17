using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.JsonToCSharp
{
    public class ModelInput
    {
        public ModelInput(string name, object value)
        {
            NameOfClass = name;
            Value = value;
        }
        public string NameOfClass { get; set; }
        public object Value { get; set; }
    }
}
