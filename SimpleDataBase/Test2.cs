using SimpleDataBase.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase
{
    public class Test2 : ID<Test2>
    {
        public Test2(int myProperty)
        {
            MyProperty = myProperty;
        }
    
        public int MyProperty { get; set; }
    }
}
