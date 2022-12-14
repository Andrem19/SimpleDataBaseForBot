using SimpleDataBase.DataBase.JsonToCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Helpers
{
    public static class GetProperties
    {
        public static int GetIndex(this Universal uni, string PropertyName)
        {
            return uni.Properties.FindIndex(x => x.Name == PropertyName);
        }
        public static Property GetProp(this Universal uni, string PropertyName)
        {
            int index = uni.Properties.FindIndex(x => x.Name == PropertyName);
            return uni.Properties[index];
        }
    }
}
