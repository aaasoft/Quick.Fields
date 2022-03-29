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
        /// 父节点
        /// </summary>
        [JsonIgnore]
        public FieldForGet Parent { get; set; }

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

        private FieldForGet[] _Children;
        /// <summary>
        /// 子字段，当类型为容器时有效
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public FieldForGet[] Children
        {
            get { return _Children; }
            set
            {
                _Children = value;
                foreach (var item in value)
                    item.Parent = this;
            }
        }

        /// <summary>
        /// 属性改变时
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 转换为FieldForPost类型的实例
        /// </summary>
        /// <returns></returns>
        public FieldForPost ToPost()
        {
            var model = new FieldForPost()
            {
                Id = Id,
                Value = Value
            };
            model.Children = Children?.Select(t =>
            {
                var child = t.ToPost();
                child.Parent = model;
                return child;
            }).ToArray();
            return model;
        }

        /// <summary>
        /// 获取完整的字段
        /// </summary>
        /// <returns></returns>
        public FieldForGet[] GetFullFields()
        {
            Stack<FieldForGet> fieldStack = new Stack<FieldForGet>();
            var currentNode = this;
            while (currentNode != null)
            {
                fieldStack.Push(currentNode);
                currentNode = currentNode.Parent;
            }
            return fieldStack.ToArray();
        }

        /// <summary>
        /// 获取完整的字段编号
        /// </summary>
        /// <returns></returns>
        public string[] GetFullFieldIds()
        {
            Stack<string> idStack = new Stack<string>();
            var currentNode = this;
            while (currentNode != null)
            {
                idStack.Push(currentNode.Id);
                currentNode = currentNode.Parent;
            }
            return idStack.ToArray();
        }
    }
}
