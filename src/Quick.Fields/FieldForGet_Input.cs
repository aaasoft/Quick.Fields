using System.Text.Json.Serialization;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 输入控件是否显示名称标签，当Type为Input时有效
        /// </summary>
        public bool? Input_ShowNameLabel { get; set; }
        /// <summary>
        /// 输入控件的前置文本，当Type为Input时有效
        /// </summary>
        public string Input_PrependText{get;set;}
        /// <summary>
        /// 输入控件的后置文本，当Type为Input时有效
        /// </summary>
        public string Input_AppendText{get;set;}
        /// <summary>
        /// 输入控件的占位符，当Type为Input时有效
        /// </summary>
        public string Input_Placeholder { get; set; }
        /// <summary>
        /// 输入控件验证用正则表达式，当Type为Input时有效
        /// </summary>
        public string Input_RegularExpression { get; set; }
        /// <summary>
        /// 输入控件是否只读，当Type为Input时有效
        /// </summary>
        public bool? Input_ReadOnly { get; set; }
        /// <summary>
        /// 输入控件是否禁用，当Type为Input时有效
        /// </summary>
        public bool? Input_Disabled { get; set; }
        /// <summary>
        /// 输入控件是否允许为空，当Type为Input时有效
        /// </summary>
        public bool? Input_AllowBlank { get; set; }
        /// <summary>
        /// 输入控件是否显示为大尺寸，当Type为Input时有效
        /// </summary>
        public bool? Input_IsLarge { get; set; }
        /// <summary>
        /// 输入控件是否显示为小尺寸，当Type为Input时有效
        /// </summary>
        public bool? Input_IsSmall { get; set; }
        /// <summary>
        /// 输入控件是否显示纯文本，当Type为Input时有效
        /// </summary>
        public bool? Input_IsPlainText { get; set; }
        /// <summary>
        /// 验证消息
        /// </summary>
        [JsonIgnore]
        public string Input_ValidationMessage { get; private set; }

        private FieldForGet[] _Input_PrependChildren;
        /// <summary>
        /// 前置子字段
        /// </summary>
        public FieldForGet[] Input_PrependChildren
        {
            get { return _Input_PrependChildren; }
            set
            {
                _Input_PrependChildren = value;
                if (value != null)
                    foreach (var item in value)
                        item.Parent = this;
            }
        }

        private FieldForGet[] _Input_AppendChildren;
        /// <summary>
        /// 后置子字段
        /// </summary>
        public FieldForGet[] Input_AppendChildren
        {
            get { return _Input_AppendChildren; }
            set
            {
                _Input_AppendChildren = value;
                if (value != null)
                    foreach (var item in value)
                        item.Parent = this;
            }
        }

        private string validate()
        {
            //验证是否为空
            if (Input_AllowBlank.HasValue && !Input_AllowBlank.Value && string.IsNullOrEmpty(Value))
                return $"字段[{Name}]的值不能为空";
            //验证是否匹配正则表达式
            if (!string.IsNullOrEmpty(Input_RegularExpression))
            {
                var regex = new System.Text.RegularExpressions.Regex(Input_RegularExpression);
                if (!regex.IsMatch(Value))
                    return $"字段[{Name}]的值格式不正确";
            }
            return null;
        }
    }
}
