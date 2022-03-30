using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 分页器控件_页大小
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Pager_PageSize { get; set; }
        /// <summary>
        /// 分页器控件_记录数量
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Pager_RecordCount { get; set; }
    }
}
