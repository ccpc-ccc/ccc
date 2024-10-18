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
        public static string GetListItemText(List<ListItem> list,string value) {
           ListItem item= list.Find(li => li.Value == value);
            if (item == null) return null;
            else return item.Text;
        }
        public static string GetListItemValue(List<ListItem> list,string text) {
           ListItem item= list.Find(li => li.Text == text);
            if (item == null) return null;
            else return item.Text;
        }
        public static List<ListItem> CumtomerList() {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("客户单位", "Customer"));
            list.Add(new ListItem("供货单位", "Supplier"));
            list.Add(new ListItem("发货单位", "Delivery"));
            list.Add(new ListItem("收货单位", "Receiver"));
            list.Add(new ListItem("承运单位", "Transfer"));
            list.Add(new ListItem("生产单位", "Manufacturer"));
            return list;
        }
    }
}
