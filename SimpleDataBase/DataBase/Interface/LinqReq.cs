using SimpleDataBase.DataBase.Models;
using SimpleDataBase.DataBase.ReadingWriting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Interface
{
    public static class LinqReq<T> where T : ID<T>
    {
        public static async Task<T> GetClass(string NameOfClass, int id)
        {
            string name = Variables.DbSet.FirstOrDefault(x => x.Name == NameOfClass).Name;
            int index = Variables.DbSet.FindIndex(x => x.Name == name);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{Variables.DbSet[index].Name}.txt");
            List<T> TList = await Reading<T>.ReadModel(path);
            T res = TList.Find(x => x.Id == id);
            if (res != null)
            {
                return res;
            }
            return null;
        }
        public static async Task<T> GetClass(string NameOfClass, Predicate<T> predicate)
        {
            string name = Variables.DbSet.FirstOrDefault(x => x.Name == NameOfClass).Name;
            int index = Variables.DbSet.FindIndex(x => x.Name == name);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{Variables.DbSet[index].Name}.txt");
            List<T> TList = await Reading<T>.ReadModel(path);
            T res = TList.Find(predicate);
            if (res != null)
            {
                return res;
            }
            return null;
        }
        public static async Task<List<T>> GetAll(string name, Func<T, bool> predicate)
        {
            int index = Variables.DbSet.FindIndex(x => x.Name == name);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{Variables.DbSet[index].Name}.txt");
            List<T> TList = await Reading<T>.ReadModel(path);
            IEnumerable<T> res = TList.Where(predicate);
            if (res != null)
            {
                return res.ToList();
            }
            return null;
        }
    }
}
