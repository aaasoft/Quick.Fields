using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// HTML标签的Class属性
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Html_Class { get; set; }
        /// <summary>
        /// HTML标签的Style属性
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Html_Style { get; set; }
    }
}
