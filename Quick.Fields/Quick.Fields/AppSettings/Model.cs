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
        public string GetValue(string fieldId)
        {
            if (Fields == null || Fields.Length == 0)
                return null;
            foreach (var field in Fields)
                if (field.Id == fieldId)
                    return field.Value;
            return null;
        }

        public void SetValue(string fieldId, string value)
        {
            foreach (var field in Fields)
                if (field.Id == fieldId)
                    field.Value = value;
        }

        /// <summary>
        /// 转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Convert<T>()
        {
            JObject jobj = new JObject();
            foreach (var field in Fields)
                if (!string.IsNullOrEmpty(field.Id))
                    jobj[field.Id] = field.Value;
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
