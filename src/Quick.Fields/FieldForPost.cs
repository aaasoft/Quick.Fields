using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Quick.Fields
{
    /// <summary>
    /// 参数字段
    /// </summary>
    public class FieldForPost
    {
        /// <summary>
        /// 父节点
        /// </summary>
        [JsonIgnore]
        public FieldForPost Parent { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// 子字段
        /// </summary>
        public FieldForPost[] Children { get; set; }

        /// <summary>
        /// 获取完整的字段
        /// </summary>
        /// <returns></returns>
        public FieldForPost[] GetFullFields()
        {
            Stack<FieldForPost> fieldStack = new Stack<FieldForPost>();
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
