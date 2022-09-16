using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.ReadingWriting
{
    public static class Reading<T>
    {
        public static async Task<List<T>> ReadModel(string path)
        {
            List<T> dataList = new();
            if (File.Exists(path))
            {
                foreach (string line in File.ReadLines(path))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var data = JsonConvert.DeserializeObject<T>(line);
                        dataList.Add(data);
                    }
                }
            }
            return dataList;
        }
    }
}
