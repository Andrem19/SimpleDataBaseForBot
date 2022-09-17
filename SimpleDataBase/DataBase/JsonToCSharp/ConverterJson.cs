using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.JsonToCSharp
{
    public static class ConverterJson
    {
        public static Universal ToCSharpClass(ModelInput obj)
        {
            var json = JsonConvert.SerializeObject(obj.Value);
            JObject jsonObj = JObject.Parse(json);
            return FromJObj(jsonObj, obj.Name);
        }
        public static Universal FromJObj(JObject jsonObj, String name)
        {
            Universal universal = new Universal(name);
            IList<string> keys = jsonObj.Properties().Select(p => p.Name).ToList();
            var types = jsonObj.Properties().Select(v => v.Value.Type).ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                Property property = new Property();
                property.Name = keys[i];
                property.Type = types[i].ToString();
                if (property.Type == JTokenType.String.ToString())
                {
                    property.ValueString = jsonObj.GetValue(property.Name).ToString();
                    universal.Properties.Add(property);
                }
                else if (property.Type == JTokenType.Integer.ToString())
                {
                    property.ValueInt = Convert.ToInt32(jsonObj.GetValue(property.Name));
                    universal.Properties.Add(property);
                }
                else if (property.Type == JTokenType.Boolean.ToString())
                {
                    property.ValueBool = (bool)jsonObj.GetValue(property.Name);
                    universal.Properties.Add(property);
                }
                else if (property.Type == JTokenType.Float.ToString())
                {
                    property.ValueFloat = (float)jsonObj.GetValue(property.Name);
                    universal.Properties.Add(property);
                }
                else if (property.Type == JTokenType.Date.ToString())
                {
                    property.ValueDate = (DateTime)jsonObj.GetValue(property.Name);
                    universal.Properties.Add(property);
                }
                else if (property.Type == JTokenType.Object.ToString())
                {
                    property.ValueObject = FromJObj((JObject)jsonObj.GetValue(property.Name), property.Name);
                    universal.Properties.Add(property);
                }
                else if (property.Type == JTokenType.Array.ToString())
                {
                    if (jsonObj.Property(property.Name).First.First.Type == JTokenType.Object)
                    {
                        var tes = jsonObj.Property(property.Name).Value.Children().ToList();
                        property.ValueListObject = new List<Universal>();
                        for (int j = 0; j < tes.Count(); j++)
                        {
                            var obj = (JObject)tes[j];
                            Universal temUni = FromJObj(obj, j.ToString());
                            property.ValueListObject.Add(temUni);
                        }
                        property.Type += "O";
                        universal.Properties.Add(property);
                    }
                    else if (jsonObj.Property(property.Name).First.First.Type == JTokenType.Integer)
                    {
                        var tes = jsonObj.Property(property.Name).Value.Children().ToList();
                        property.ValueListInt = new List<int>();
                        for (int j = 0; j < tes.Count(); j++)
                        {
                            var obj = (int)tes[j];
                            property.ValueListInt.Add(obj);
                        }
                        property.Type += "I";
                        universal.Properties.Add(property);
                    }
                    else if (jsonObj.Property(property.Name).First.First.Type == JTokenType.String)
                    {
                        var tes = jsonObj.Property(property.Name).Value.Children().ToList();
                        property.ValueListString = new List<string>();
                        for (int j = 0; j < tes.Count(); j++)
                        {
                            var obj = tes[j].ToString();
                            property.ValueListString.Add(obj);
                        }
                        property.Type += "S";
                        universal.Properties.Add(property);
                    }
                }
            }

            return universal;
        }
    }
}
