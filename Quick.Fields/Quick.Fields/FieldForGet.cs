using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet : INotifyPropertyChanged
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType Type { get; set; } = FieldType.InputText;
        /// <summary>
        /// 宽度
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }
        /// <summary>
        /// 当值改变时，是否提交
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? PostOnChanged { get; set; }

        private string _Value;
        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                Input_ValidationMessage = validate();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        /// <summary>
        /// 子字段，当类型为容器时有效
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public FieldForGet[] Children { get; set; }

        /// <summary>
        /// 属性改变时
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public FieldForPost ToPost()
        {
            return new FieldForPost()
            {
                Id = Id,
                Value = Value,
                Children = Children?.Select(t => t.ToPost()).ToArray()
            };
        }
    }
}
