using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 文件过滤器，比如：*.jpg，当类型为InputFile时有效
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InputFile_FileFilter { get; set; }
    }
}
