using SimpleDataBase.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase
{
    public class TestModel : ID
    {
        public TestModel(string name, int number, Test2 prop)
        {
            Name = name;
            Number = number;
            List<Test2> pro = new List<Test2>();
            pro.Add(prop);
            pro.Add(prop);
            pro.Add(prop);
            PropList = pro;
            PropIntL = new List<int> { 1, 2, 3 };
            PropStrL = new List<string> { "First", "Second", "Third" };
            Prop = prop;
            bl = true;
            gd = new Guid();
            dt = new DateTime(2000, 12, 5, 15, 45, 0);
            ts = TimeSpan.FromDays(3);
            fl = 100f;
            db = 1550.6;
        }
    
        public string Name { get; set; }
        public int Number { get; set; }
        public Test2 Prop { get; set; }
        public bool bl { get; set; }
        public Guid gd { get; set; }
        public DateTime dt { get; set; }
        public TimeSpan ts { get; set; }
        public float fl { get; set; }
        public double db { get; set; }
        public List<Test2> PropList { get; set; } = new List<Test2>();
        public List<int> PropIntL { get; set; } = new List<int>();
        public List<string> PropStrL { get; set; } = new List<string>();
    }
}
