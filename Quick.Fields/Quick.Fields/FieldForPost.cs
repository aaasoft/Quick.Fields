using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Quick.Fields
{
    /// <summary>
    /// 参数字段
    /// </summary>
    public class FieldForPost
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public virtual string Value { get; set; }
    }
}
