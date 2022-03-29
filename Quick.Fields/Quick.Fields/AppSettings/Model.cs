using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quick.Fields.AppSettings
{
    public class Model
    {
        public const string APPSETTINGS_JSON_FILENAME = "appsettings.json";
        public JObject Raw { get; private set; }
        public FieldForGet[] Fields { get; set; }

        private FieldForGet findField(FieldForGet[] items, string fieldId)
        {
            if (items == null || fieldId == null)
                return null;

            foreach (var item in items)
            {
                if (fieldId == item.Id)
                    return item;
                var subItem = findField(item.Children, fieldId);
                if (subItem != null)
                    return subItem;
            }
            return null;
        }

        public string GetValue(string fieldId)
        {
            var field = findField(Fields, fieldId);
            if (field == null)
                return null;
            return field.Value;
        }

        public void SetValue(string fieldId, string value)
        {
            var field = findField(Fields, fieldId);
            if (field == null)
                return;
            field.Value = value;
        }

        private void fillJObjectValue(FieldForGet[] items, JObject jobj)
        {
            if (items == null || items.Length == 0)
                return;
            foreach (var field in items)
            {
                if (!string.IsNullOrEmpty(field.Id))
                    jobj[field.Id] = field.Value;
                fillJObjectValue(field.Children, jobj);
            }
        }

        /// <summary>
        /// 转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Convert<T>()
        {
            JObject jobj = new JObject();
            fillJObjectValue(Fields, jobj);
            return jobj.ToObject<T>();
        }

        public static Model Load()
        {
            return Load(APPSETTINGS_JSON_FILENAME);
        }

        public static Model Load(string path)
        {
            var content = File.ReadAllText(path);
            var model = JsonConvert.DeserializeObject<Model>(content);
            model.Raw = JObject.Parse(content);
            return model;
        }

        public void Save()
        {
            Save(APPSETTINGS_JSON_FILENAME, Encoding.UTF8);
        }

        public void Save(string path, Encoding encoding)
        {
            var content = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, content, encoding);
        }
    }
}
