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
            Type classT = typeof(T);
            string name = classT.Name;
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
        public static async Task<List<T>> GetSet()
        {
            Type classT = typeof(T);
            string name = classT.Name;
            int ind = Variables.DbSet.FindIndex(x => x.Name == name);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[ind].Id}-{Variables.DbSet[ind].Name}.txt");
            return await Reading<T>.ReadModel(path);
        }

        public static async Task<T> GetClass(int id)
        {
            Type classT = typeof(T);
            string name = classT.Name;
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
        public static async Task<T> GetClass(Predicate<T> predicate)
        {
            Type classT = typeof(T);
            string name = classT.Name;
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
        public static async Task<List<T>> GetAll(Func<T, bool> predicate)
        {
            Type classT = typeof(T);
            string name = classT.Name;
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
        public static async Task Update(T model)
        {
            Type classT = typeof(T);
            string name = classT.Name;
            int index = GetClassName.GetClassIndex(classT);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{name}.txt");
            List<T> data = await Reading<T>.ReadModel(path);
            var tempModel = data.FirstOrDefault(x => x.Id == model.Id);
            data.Remove(tempModel);
            data.Add(model);
            await Writing<T>.ReWrite(path, data, FileMode.Append);
        }
        public static async Task DeleteSet()
        {
            Type classT = typeof(T);
            string name = classT.Name;
            int index = GetClassName.GetClassIndex(classT);
            string path = Path.Combine("DbModels", $"{Variables.DbSet[index].Id}-{name}.txt");
            File.Delete(path);
            Variables.DbSet.RemoveAt(index);
            if (Variables.DbSet.Count > 0)
            {
                await Writing<T>.ReWriteInfoDbModel(Variables.DbSet, FileMode.Append);
            }
            else
            {
                File.Delete("DbSet.txt");
                if (Directory.EnumerateFiles("DbModels").Count() == 0)
                {
                    Directory.Delete("DbModels");
                }
            }
        }
        public static async Task Delete(T model)
        {
            Type classT = typeof(T);
            string name = classT.Name;
            var set = Variables.DbSet.FirstOrDefault(x => x.Name == name);
            string path = Path.Combine("DbModels", $"{set.Id}-{name}.txt");
            List<T> data = await Reading<T>.ReadModel(path);
            var mod = data.FirstOrDefault(x => x.Id == model.Id);
            data.Remove(mod);
            int index = GetClassName.GetClassIndex(classT);
            if (data.Count > 0)
            {
                await Writing<T>.ReWrite(path, data, FileMode.Append);
                Variables.DbSet[index].Count -= 1;
                await Writing<T>.ReWriteInfoDbModel(Variables.DbSet, FileMode.Append);
            }
            else
            {
                File.Delete(path);
                if (Directory.EnumerateFiles("DbModels").Count() == 0)
                {
                    Directory.Delete("DbModels");
                }
                Variables.DbSet.RemoveAt(index);
                await Writing<T>.ReWriteInfoDbModel(Variables.DbSet, FileMode.Append);
            }
        }
        public static async Task Delete(int id)
        {
            Type classT = typeof(T);
            string name = classT.Name;
            var set = Variables.DbSet.FirstOrDefault(x => x.Name == name);
            string path = Path.Combine("DbModels", $"{set.Id}-{name}.txt");
            List<T> data = await Reading<T>.ReadModel(path);
            var model = data.FirstOrDefault(x => x.Id == id);
            data.Remove(model);
            int index = GetClassName.GetClassIndex(classT);
            if (data.Count > 0)
            {
                await Writing<T>.ReWrite(path, data, FileMode.Append);
                Variables.DbSet[index].Count -= 1;
                await Writing<T>.ReWriteInfoDbModel(Variables.DbSet, FileMode.Append);
            }
            else
            {
                File.Delete(path);
                if (Directory.EnumerateFiles("DbModels").Count() == 0)
                {
                    Directory.Delete("DbModels");
                }
                Variables.DbSet.RemoveAt(index);
                await Writing<T>.ReWriteInfoDbModel(Variables.DbSet, FileMode.Append);
            }
        }
    }
}
