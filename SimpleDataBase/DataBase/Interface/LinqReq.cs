using SimpleDataBase.DataBase.JsonToCSharp;
using SimpleDataBase.DataBase.Models;
using SimpleDataBase.DataBase.ReadingWriting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.Interface
{
    public static class LinqReq
    {
        public static List<Universal> GetInstancesMore(List<Universal> uni, string PropertyName, int Value)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt > Value)).ToList();
        }
        public static List<Universal> GetInstancesLess(List<Universal> uni, string PropertyName, int Value)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt < Value)).ToList();
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, bool Value)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueBool == Value));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, string Value)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, int Value)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, string Value, string PropertyName2, string Value2)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, int Value, string PropertyName2, int Value2)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueInt == Value2));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, int Value, string PropertyName2, string Value2)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, int Value, string PropertyName2, int Value2, bool or)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) || x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueInt == Value2));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, int Value, string PropertyName2, string Value2, bool or)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) || x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2));
        }
        public static Universal GetInstance(List<Universal> uni, string PropertyName, string Value, string PropertyName2, string Value2, bool or)
        {
            return uni.FirstOrDefault(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value) || x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2));
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, bool Value)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueBool == Value)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, string Value)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, int Value)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, string Value, string PropertyName2, string Value2)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, int Value, string PropertyName2, int Value2)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueInt == Value2)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, int Value, string PropertyName2, string Value2)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, string Value, string PropertyName2, int Value2)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value) && x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueInt == Value2)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, int Value, string PropertyName2, int Value2, bool or)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) || x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueInt == Value2)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, int Value, string PropertyName2, string Value2, bool or)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueInt == Value) || x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2)).ToList();
        }
        public static List<Universal> GetInstances(List<Universal> uni, string PropertyName, string Value, string PropertyName2, string Value2, bool or)
        {
            return uni.Where(x => x.Properties.Exists(c => c.Name == PropertyName && c.ValueString == Value) || x.Properties.Exists(c => c.Name == PropertyName2 && c.ValueString == Value2)).ToList();
        }
    }
}
