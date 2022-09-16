using SimpleDataBase.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase
{
    internal class Test2 : ID
    {
        public Test2(int myProperty)
        {
            MyProperty = myProperty;
        }
    
        public int MyProperty { get; set; }
    }
}
