﻿using SimpleDataBase.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase
{
    public class TestModel : ID
    {
        public TestModel(string name, int number)
        {
            Name = name;
            Number = number;
        }
    
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
