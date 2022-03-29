﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 选择输入控件的选择项字典
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, string> InputSelect_Options { get; set; }
        /// <summary>
        /// 枚举的编号是否使用整数值
        /// </summary>
        [JsonIgnore]
        public bool InputSelect_OptionsEnumIdUseIntValue { get; set; } = true;
        /// <summary>
        /// 根据枚举类型设置Options参数的值
        /// </summary>
        public Type InputSelect_OptionsEnum
        {
            set
            {
                var type = value;
                if (type == null)
                    return;

                if (!type.IsEnum)
                    return;

                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (var key in Enum.GetNames(type))
                {
                    var e = Enum.Parse(type, key);
                    var name = key;
                    var attrs = type.GetMember(key)[0].GetCustomAttributes(false);
                    foreach (var attr in attrs)
                    {
                        if (attr is DescriptionAttribute)
                        {
                            name = ((DescriptionAttribute)attr).Description;
                            break;
                        }
                    }
                    var enumKey = key;
                    if (InputSelect_OptionsEnumIdUseIntValue)
                        enumKey = Convert.ToInt32(e).ToString();
                    dict[enumKey] = name;
                }
                InputSelect_Options = dict;
            }
        }
    }
}