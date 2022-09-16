using Newtonsoft.Json;
using SimpleDataBase;
using SimpleDataBase.DataBase.Core;
using SimpleDataBase.DataBase.Helpers;

namespace Data
{
    public class DataBase
    {
        public static async Task Main()
        {
            //await Init.StartInit();
            TestModel model = new TestModel();
            Console.WriteLine(GetClassName.GetName(model.ToString()));
            Console.ReadLine();
            await Db<TestModel>.GetClass(GetClassName.GetName(model.ToString()), x => x.Number == 123);
        }
    }
}
