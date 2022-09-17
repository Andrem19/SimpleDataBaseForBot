using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleDataBase;
using SimpleDataBase.DataBase;
using SimpleDataBase.DataBase.Core;
using SimpleDataBase.DataBase.Helpers;
using SimpleDataBase.DataBase.JsonToCSharp;
using System.Text.RegularExpressions;

namespace Data
{
    public class DataBase
    {
        public static async Task Main()
        {
            await Init.StartInit();
            Test2 test = new Test2(12);
            TestModel model1 = new TestModel("Andrew", 31, test);
            TestModel model2 = new TestModel("Ira", 27, test);
            TestModel model3 = new TestModel("Gabi", 9, test);
            TestModel model4 = new TestModel("Yan", 6, test);
            //ModelInput model = new ModelInput("TestModel", model1);
            string json = JsonConvert.SerializeObject(model1);
            Universal uniModel = ConverterJson.ToCSharpClass(json);
            string res = uniModel.ToJson();
            if (json == res)
            {
                Console.WriteLine("SUCCESS");
            }
            uniModel = ConverterJson.ToCSharpClass(res);
            res = uniModel.ToJson();
            if (json == res)
            {
                Console.WriteLine("SUCCESS");
            }
            //string str = Regex.Replace(json, "[^a-zA-Z0-9,:']", String.Empty);
            //string[] res = str.Split(new[] { '\u002C' }, StringSplitOptions.RemoveEmptyEntries);
            //Dictionary<string, string> r = new Dictionary<string, string>();
            //for (int i = 0; i < res.Length; i++)
            //{
            //    string[] d = res[i].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            //    r.Add(d[0], d[1]);
            //}
            ////Test2 test = new Test2(12);
            ////await Db<Test2>.Add(test);
            //await Db<TestModel>.Add(model1);
            //await Db<TestModel>.Add(model2);
            //await Db<TestModel>.Add(model3);
            //await Db<TestModel>.Add(model4);
            //var res = Variables.DbSet;
            //List<TestModel> TestM = await Db<TestModel>.GetSet();
            //TestModel Gabi = TestM.FirstOrDefault(x => x.Name == "Gabi");
            //TestModel Yan = TestM.FirstOrDefault(x => x.Name == "Yan");
            //TestModel Ira = TestM.FirstOrDefault(x => x.Name == "Ira");
            //TestModel Andrew = TestM.FirstOrDefault(x => x.Name == "Andrew");
            //TestModel Gb = await Db<TestModel>.GetClass(Gabi.Id);
            //TestModel And = await Db<TestModel>.GetClass(x => x.Number == 31);
            //List<TestModel> AllAdult = await Db<TestModel>.GetAll(x => x.Number > 18);
            //And.Number = 32;
            //await Db<TestModel>.Update(And);
            //await Db<TestModel>.Delete(Ira);
            //await Db<TestModel>.Delete(Gabi.Id);
            //var res2 = Variables.DbSet;
            //List<TestModel> TestM2 = await Db<TestModel>.GetSet();
            //await Init.StartInit();
            //var res3 = Variables.DbSet;
            //await Db<TestModel>.DeleteSet();
        }
    }
}
