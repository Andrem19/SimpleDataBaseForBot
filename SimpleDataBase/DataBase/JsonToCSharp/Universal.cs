using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleDataBase.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.JsonToCSharp
{
    public class Universal : ID<Universal>
    {
        public List<Property> Properties { get; set; } = new List<Property>();
    }
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Property
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string? ValueString { get; set; }
        public int? ValueInt { get; set; }
        public bool? ValueBool { get; set; }
        public float? ValueFloat { get; set; }
        public DateTime? ValueDate { get; set; }
        public List<string>? ValueListString { get; set; }
        public List<int>? ValueListInt { get; set; }
        public Universal? ValueObject { get; set; }
        public List<Universal>? ValueListObject { get; set; }
    }
}
