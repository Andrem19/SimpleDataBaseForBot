using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase
{
    public static class Variables
    {
        public static string NameOfDB { get; set; } = "TestDB";
        public static List<Models.Models> DbSet { get; set; } = new List<Models.Models>();
    }
}
