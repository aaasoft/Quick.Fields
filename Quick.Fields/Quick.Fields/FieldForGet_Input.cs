using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 输入控件验证用正则表达式，当Type为Input时有效
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Input_RegularExpression { get; set; }
        /// <summary>
        /// 输入控件是否只读，当Type为Input时有效
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Input_ReadOnly { get; set; } = false;
        /// <summary>
        /// 输入控件是否允许为空，当Type为Input时有效
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Input_AllowBlank { get; set; } = true;
        /// <summary>
        /// 验证消息
        /// </summary>
        [JsonIgnore]
        public string Input_ValidationMessage { get; private set; }

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
