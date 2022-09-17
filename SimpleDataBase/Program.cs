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

            string json1 = JsonConvert.SerializeObject(model1);
            string json2 = JsonConvert.SerializeObject(model2);
            string json3 = JsonConvert.SerializeObject(model3);
            string json4 = JsonConvert.SerializeObject(model4);
            Universal uniModel1 = ConverterJson.ToCSharpClass(json1);
            Universal uniModel2 = ConverterJson.ToCSharpClass(json2);
            Universal uniModel3 = ConverterJson.ToCSharpClass(json3);
            Universal uniModel4 = ConverterJson.ToCSharpClass(json4);
            await Db<Universal>.Add(uniModel1);
            await Db<Universal>.Add(uniModel2);
            await Db<Universal>.Add(uniModel3);
            await Db<Universal>.Add(uniModel4);
            List<Universal> TestM = await Db<Universal>.GetSet("TestModel");
            Universal Ira = TestM.FirstOrDefault(x => x.Properties.Exists(c => c.Name == "Name" && c.ValueString == "Ira"));
            Universal Andrew = TestM.FirstOrDefault(x => x.Properties.Exists(c => c.Name == "Number" && c.ValueInt == 31) && x.Properties.Exists(c => c.Name == "Name" && c.ValueString == "Andrew"));
            Andrew.Properties[Andrew.GetIndex("Number")].ValueInt = 32;
            Andrew.GetProp("Name").ValueString = "Oscar";
            await Db<Universal>.Delete("TestModel", Ira);
            await Db<Universal>.Update("TestModel", Andrew);
            var re = Variables.DbSet;
            TestM = await Db<Universal>.GetSet("TestModel");
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
            await Db<Universal>.DeleteSet("TestModel");
        }
    }
}
