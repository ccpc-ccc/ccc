using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YF.MWS.Metadata
{
    public class ListItem
    {
        public string Text { get; set; }

        public string Value { get; set; }
        public int Index { get; set; }
        public ListItem() { }
        public ListItem(string text,string value) {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
    public static class ClassUtil {
        public static T convert<T>(this object obj) where T : new() {
            PropertyInfo[] p = obj.GetType().GetProperties();
            T t = new T();
            foreach (PropertyInfo info in p) {
                if (t.GetType().GetProperty(info.Name) == null) continue;
                info.SetValue(t, info.GetValue(obj));
            }
            return t;
        }
    }
}
