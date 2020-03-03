using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quick.Fields.AppSettings
{
    public class Model
    {
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

        public static Model Load()
        {
            return Load("appsettings.json");
        }

        public static Model Load(string path)
        {
            var content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Model>(content);
        }
    }
}
