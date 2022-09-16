using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Models
{
    public class Models
    {
        public Models()
        {

        }
        public Models(int id, string name, int count)
        {
            Id = id;
            Name = name;
            Count = count;
            MaxId = 1;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxId { get; set; }
        public int Count { get; set; }
    }
}
