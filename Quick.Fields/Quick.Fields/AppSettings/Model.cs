using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Quick.Fields.AppSettings
{
    [JsonSerializable(typeof(Model))]
    [JsonSourceGenerationOptions(WriteIndented = true)]
    internal partial class ModelSerializerContext : JsonSerializerContext { }

    public class Model
    {
        public const string APPSETTINGS_JSON_FILENAME = "appsettings.json";
        public JsonObject Raw { get; private set; }
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

        private void fillJObjectValue(FieldForGet[] items, JsonObject jobj)
        {
            if (items == null || items.Length == 0)
                return;
            foreach (var field in items)
            {
                if (!string.IsNullOrEmpty(field.Id))
                {
                    jobj[field.Id] = field.Value;
                    //如果是InputSelect类型
                    if (field.Type == FieldType.InputSelect)
                    {
                        //如果能转换为布尔类型
                        if (bool.TryParse(field.Value, out var b))
                            jobj[field.Id] = b;
                    }
                    //如果是数字类型
                    else if (field.Type == FieldType.InputNumber)
                    {
                        //如果能转换为数字
                        if (decimal.TryParse(field.Value, out var d))
                            jobj[field.Id] = d;
                    }
                }
                fillJObjectValue(field.Children, jobj);
            }
        }

        /// <summary>
        /// 转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Convert<T>(JsonSerializerContext jsonSerializerContext)
        {
            var jobj = new JsonObject();
            fillJObjectValue(Fields, jobj);
            return (T)jobj.Deserialize(typeof(T), jsonSerializerContext);
        }

        public static Model Load()
        {
            return Load(APPSETTINGS_JSON_FILENAME);
        }

        public static Model Load(string path)
        {
            var content = File.ReadAllText(path);
            var model = (Model)JsonSerializer.Deserialize(content, typeof(Model), ModelSerializerContext.Default);
            model.Raw = JsonNode.Parse(content).AsObject();
            return model;
        }

        public static Model FromJsonString(string json)
        {
            return (Model)JsonSerializer.Deserialize(json, typeof(Model), ModelSerializerContext.Default);
        }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this, typeof(Model), ModelSerializerContext.Default);
        }

        public void Save()
        {
            Save(APPSETTINGS_JSON_FILENAME, Encoding.UTF8);
        }

        public void Save(string path, Encoding encoding)
        {
            var content = JsonSerializer.Serialize(this, typeof(Model), ModelSerializerContext.Default);
            File.WriteAllText(path, content, encoding);
        }
    }
}
