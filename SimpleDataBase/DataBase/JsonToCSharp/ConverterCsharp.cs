using SimpleDataBase.DataBase.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataBase.DataBase.JsonToCSharp
{
    public static class ConverterCsharp
    {
        public static string ToJson(this Universal uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int i = 0; i < uni.Properties.Count; i++)
            {
                if (uni.Properties[i].Type == "String")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].ValueString);
                    sb.Append("\"");
                    if (i != uni.Properties.Count-1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "Date")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append("\"");
                    sb.Append(Helpers.Data.Convert(uni.Properties[i].ValueDate.ToString()));
                    sb.Append("\"");
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "Integer")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append(uni.Properties[i].ValueInt);
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "Boolean")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    string val = uni.Properties[i].ValueBool == true ? "true" : "false";
                    sb.Append(val);
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "Float")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append(FloatConverter.FloatToString(uni.Properties[i].ValueFloat));
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "Object")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append(uni.Properties[i].ValueObject.ToJson());
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "ArrayO")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append("[");
                    for (int j = 0; j < uni.Properties[i].ValueListObject.Count; j++)
                    {
                        sb.Append(uni.Properties[i].ValueListObject[j].ToJson());
                        if (j != uni.Properties[i].ValueListObject.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "ArrayI")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append("[");
                    for (int j = 0; j < uni.Properties[i].ValueListInt.Count; j++)
                    {
                        sb.Append(uni.Properties[i].ValueListInt[j]);
                        if (j != uni.Properties[i].ValueListInt.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                if (uni.Properties[i].Type == "ArrayS")
                {
                    sb.Append("\"");
                    sb.Append(uni.Properties[i].Name);
                    sb.Append("\"");
                    sb.Append(":");
                    sb.Append("[");
                    for (int j = 0; j < uni.Properties[i].ValueListString.Count; j++)
                    {
                        sb.Append("\"");
                        sb.Append(uni.Properties[i].ValueListString[j]);
                        sb.Append("\"");
                        if (j != uni.Properties[i].ValueListString.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                    if (i != uni.Properties.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("}");
            string res = sb.ToString();
            return res;
        }
    }
}
