using Newtonsoft.Json;
using SimpleDataBase.DataBase.Helpers;
using SimpleDataBase.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.ReadingWriting
{
    public static class Writing<T> where T : ID<T>
    {
        public async static Task<int> WriteModel(string filename, T model, FileMode fileMode)
        {
            if (!Directory.Exists(Variables.NameOfDB))
            {
                Directory.CreateDirectory(Variables.NameOfDB);
            }
            string folderName = $"DbModels";
            string p = Path.Combine(Variables.NameOfDB, folderName);
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }
            string path = Path.Combine(Variables.NameOfDB, folderName, $"{filename}.txt");
            if (!File.Exists(path))
            {
                int Id = Variables.DbSet.Count() + 1;
                await WriteInfoDbModel(new Models.Models(Id, filename, 1), FileMode.Append);
                path = Path.Combine(Variables.NameOfDB, folderName, $"{Id}-{filename}.txt");
                model.Id = 1;
                string output = JsonConvert.SerializeObject(model);
                using (FileStream file = new FileStream(path, fileMode))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.WriteLine(output);
                return 1;
            }
            else
            {
                int index = Variables.DbSet.FindIndex(x => x.Name == GetClassName.GetNameFromPath(filename));
                if (index == -1)
                {
                    var DbSetFromServer = await Reading<Models.Models>.ReadModel("DbSet.txt");
                    index = DbSetFromServer.FindIndex(x => x.Name == GetClassName.GetNameFromPath(filename));
                    if (index == -1) return -1;
                }
                model.Id = Variables.DbSet[index].MaxId + 1;
                
                string output = JsonConvert.SerializeObject(model);
                using (FileStream file = new FileStream(path, fileMode))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.WriteLine(output);

                Variables.DbSet[index].MaxId += 1;
                Variables.DbSet[index].Count += 1;
                await ReWriteInfoDbModel(Variables.DbSet, FileMode.Append);
                return model.Id;
            }
        }
        public async static Task WriteInfoDbModel(Models.Models model, FileMode fileMode)
        {
            Variables.DbSet.Add(model);
            string filename = $"DbSet.txt";
            string path = Path.Combine(Variables.NameOfDB, filename);
            string output = JsonConvert.SerializeObject(model);
            using (FileStream file = new FileStream(path, fileMode))
            using (StreamWriter stream = new StreamWriter(file))
                stream.WriteLine(output);
        }
        public async static Task ReWriteInfoDbModel(List<Models.Models> modelList, FileMode fileMode)
        {
            string filePath = Path.Combine(Variables.NameOfDB, "DbSet.txt");
            File.Delete(filePath);
            for (int i = 0; i < modelList.Count; i++)
            {
                string output = JsonConvert.SerializeObject(modelList[i]);
                using (FileStream file = new FileStream(filePath, fileMode))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.WriteLine(output);
            }
        }
        public async static Task ReWrite(string path, List<T> modelList, FileMode fileMode)
        {
            File.Delete(path);
            for (int i = 0; i < modelList.Count; i++)
            {
                string output = JsonConvert.SerializeObject(modelList[i]);
                using (FileStream file = new FileStream(path, fileMode))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.WriteLine(output);
            }
        }
    }
}
