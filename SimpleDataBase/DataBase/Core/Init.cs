using SimpleDataBase.DataBase.ReadingWriting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Core
{
    public static class Init
    {
        public static async Task StartInit()
        {
            string path = Path.Combine(Variables.NameOfDB, "DbSet.txt");
            var DbSet = await Reading<Models.Models>.ReadModel(path);
            if (DbSet.Count>0)
            {
                Variables.DbSet = DbSet;
            }
        }
    }
}
