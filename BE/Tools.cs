using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BE
{
    public static class Tools
    {
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            return str;
        }
        public static T GetCopy<T>(this T t) where T : new()
        {
            T result = new T();

            foreach (PropertyInfo item in t.GetType().GetProperties())
            {
                object val = item.GetValue(t, null);
                item.SetValue(result, val);
            }
            return result;
        }
    }
}
