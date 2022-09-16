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
            var DbSet = await Reading<Models.Models>.ReadModel("DbSet.txt");
            if (DbSet.Count>0)
            {
                Variables.DbSet = DbSet;
            }
        }
    }
}
