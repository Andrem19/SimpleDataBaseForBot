using SimpleDataBase.DataBase.Helpers;
using SimpleDataBase.DataBase.Models;
using SimpleDataBase.DataBase.ReadingWriting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Core
{
    public static class Db<T> where T : ID
    {
        public static async Task<int> Add(T model)
        {
            string name = GetClassName.GetName(model.ToString());
            int index = Variables.DbSet.FindIndex(x => x.Name == name);
            if (index == -1)
            {
                return await Writing<T>.WriteModel(name, model, FileMode.Append);
            }
            else
            {
                return await Writing<T>.WriteModel($"{Variables.DbSet[index].Id}-{name}", model, FileMode.Append);
            }
        }
        public static async Task<List<T>> GetSet(int Index)
        {
            int ind = Variables.DbSet.FindIndex(x => x.Id == Index);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[ind].Id}-{Variables.DbSet[ind].Name}.txt");
            return await Reading<T>.ReadModel(path);
        }
        public static async Task<List<T>> GetSet(string Name)
        {
            int index = Variables.DbSet.FindIndex(x => x.Name == Name);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{Variables.DbSet[index].Name}.txt");
            return await Reading<T>.ReadModel(path);
        }
        public static async Task<T> GetClass(string SetName, int id)
        {
            int index = Variables.DbSet.FindIndex(x => x.Name == SetName);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{Variables.DbSet[index].Name}.txt");
            List<T> TList = await Reading<T>.ReadModel(path);
            T res = TList.Find(x => x.Id == id);
            if (res != null)
            {
                return res;
            }
            return null;
        }
        public static async Task<T> GetClass(string SetName, Predicate<T> predicate)
        {
            int index = Variables.DbSet.FindIndex(x => x.Name == SetName);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{Variables.DbSet[index].Name}.txt");
            List<T> TList = await Reading<T>.ReadModel(path);
            T res = TList.Find(predicate);
            if (res != null)
            {
                return res;
            }
            return null;
        }
        public static async Task Update(T model)
        {

        }
        public static async Task Delete(T model)
        {
            int id = model.Id;
            string name = GetClassName.GetName(model.ToString());
            string path = Path.Combine("DbModels", $"{id}-{name}.txt");
            List<T> data = await Reading<T>.ReadModel(path);
            data.Remove(model);
            await Writing<T>.ReWrite(path, data, FileMode.Append);
        }
        public static async Task Delete(int id)
        {

        }
    }
}
