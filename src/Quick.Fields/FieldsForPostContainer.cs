using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace Quick.Fields
{
    public class FieldsForPostContainer
    {
        public FieldForPost[] Fields { get; set; }

        private FieldForPost findField(FieldForPost[] currentFields, string fieldId)
        {
            if (currentFields == null
                || currentFields.Length == 0
                || string.IsNullOrEmpty(fieldId))
                return null;
            var currentField = currentFields.FirstOrDefault(t => fieldId == t.Id);
            if (currentField != null)
                return currentField;
            foreach (var field in currentFields)
            {
                currentField = findField(field.Children, fieldId);
                if (currentField != null)
                    return currentField;
            }
            return null;
        }

        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="fieldIds"></param>
        /// <returns></returns>
        public FieldForPost GetField(params string[] fieldIds)
        {
            var currentFields = Fields;
            FieldForPost currentField = null;
            foreach (var fieldId in fieldIds)
            {
                currentField = findField(currentFields, fieldId);
                if (currentField == null)
                    return null;
                currentFields = currentField.Children;
            }
            return currentField;
        }

        /// <summary>
        /// 获取字段的值
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public string GetFieldValue(params string[] fieldIds)
        {
            return GetField(fieldIds)?.Value;
        }

        private void fillJObjectValue(FieldForPost[] items, JsonObject jobj)
        {
            if (items == null || items.Length == 0)
                return;
            foreach (var field in items)
            {
                if (!string.IsNullOrEmpty(field.Id))
                {
                    jobj[field.Id] = field.Value;
                }
                fillJObjectValue(field.Children, jobj);
            }
        }

        /// <summary>
        /// 转换为指定类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Convert<T>(JsonTypeInfo<T> jsonTypeInfo)
        {
            JsonObject jobj = new JsonObject();
            fillJObjectValue(Fields, jobj);
            return jobj.Deserialize(jsonTypeInfo);
        }
    }
}
