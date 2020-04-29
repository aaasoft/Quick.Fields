using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Quick.Fields
{
    public class FieldForGet : FieldForPost, INotifyPropertyChanged
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType Type { get; set; } = FieldType.InputText;
        /// <summary>
        /// 只读，当Type为Button、Alert或者Toast时，true代表danger，false代表primary
        /// </summary>
        public bool ReadOnly { get; set; } = false;
        /// <summary>
        /// 允许为空
        /// </summary>
        public bool AllowBlank { get; set; } = true;
        /// <summary>
        /// 当值改变时，是否提交
        /// </summary>
        public bool PostOnChanged { get; set; } = false;
        /// <summary>
        /// 选择输入控件的选择项字典
        /// </summary>
        public IDictionary<string, string> Options { get; set; }
        /// <summary>
        /// 根据枚举类型设置Options参数的值
        /// </summary>
        public Type OptionsEnum
        {
            set
            {
                var type = value;
                if (type == null)
                    return;
#if !NETSTANDARD1_5
                if (!type.IsEnum)
                    return;
#endif
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var name in Enum.GetNames(type))
                {
                    var e = Enum.Parse(type, name);
                    dict[Convert.ToInt32(e).ToString()] = name;
                }
                Options = dict;
            }
        }

        /// <summary>
        /// 验证用正则表达式
        /// </summary>
        public string RegularExpression { get; set; }

        /// <summary>
        /// 验证消息
        /// </summary>
        [JsonIgnore]
        public string ValidationMessage { get; private set; }

        /// <summary>
        /// 值
        /// </summary>
        public override string Value
        {
            get { return base.Value; }
            set
            {
                base.Value = value;
                ValidationMessage = validate();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        private string validate()
        {
            //验证是否为空
            if (!AllowBlank && string.IsNullOrEmpty(Value))
                return $"字段[{Name}]的值不能为空";
            //验证是否匹配正则表达式
            if (!string.IsNullOrEmpty(RegularExpression))
            {
                var regex = new System.Text.RegularExpressions.Regex(RegularExpression);
                if (!regex.IsMatch(Value))
                    return $"字段[{Name}]的值格式不正确";
            }
            return null;
        }

        /// <summary>
        /// 属性改变时
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
