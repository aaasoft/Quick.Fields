using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ContainerTableTd_RowSpan { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ContainerTableTd_ColSpan { get; set; }
    }
}
