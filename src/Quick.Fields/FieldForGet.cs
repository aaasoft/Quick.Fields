using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;

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
        public string Description { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter<FieldTheme>))]
        public FieldTheme? Theme { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter<FieldType>))]
        public FieldType Type { get; set; } = FieldType.InputText;
        /// <summary>
        /// 列宽度
        /// </summary>
        public int? ColumnWidth { get; set; }
        /// <summary>
        /// 外边距
        /// </summary>
        public int? Margin { get; set; }
        /// <summary>
        /// 左外边距
        /// </summary>
        public int? MarginLeft { get; set; }
        /// <summary>
        /// 右外边距
        /// </summary>
        public int? MarginRight { get; set; }
        /// <summary>
        /// 上外边距
        /// </summary>
        public int? MarginTop { get; set; }
        /// <summary>
        /// 下外边距
        /// </summary>
        public int? MarginBottom { get; set; }
        /// <summary>
        /// 内边距
        /// </summary>
        public int? Padding { get; set; }
        /// <summary>
        /// 左内边距
        /// </summary>
        public int? PaddingLeft { get; set; }
        /// <summary>
        /// 右内边距
        /// </summary>
        public int? PaddingRight { get; set; }
        /// <summary>
        /// 上内边距
        /// </summary>
        public int? PaddingTop { get; set; }
        /// <summary>
        /// 下内边距
        /// </summary>
        public int? PaddingBottom { get; set; }
        /// <summary>
        /// 当值改变时，是否提交
        /// </summary>
        public bool? PostOnChanged { get; set; }

        private string _Value;
        /// <summary>
        /// 值
        /// </summary>
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
        public FieldForGet[] Children
        {
            get { return _Children; }
            set
            {
                _Children = value;
                if (value != null)
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
                if (!string.IsNullOrEmpty(currentNode.Id))
                {
                    idStack.Push(currentNode.Id);
                }
                currentNode = currentNode.Parent;
            }
            return idStack.ToArray();
        }
    }
}
