using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Models
{
    public class ID<T> where T : class
    {
        public int Id { get; set; }
        public string NameOfClass { get; set; }
        public ID()
        {
            NameOfClass = typeof(T).Name;
        }
    }
}
