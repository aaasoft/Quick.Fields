using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Quick.Fields
{
    /// <summary>
    /// 字段抽象类
    /// </summary>
    public abstract class AbstractField<T> where T : AbstractField<T>
    {
        /// <summary>
        /// 父节点
        /// </summary>
        [JsonIgnore]
        public virtual T Parent { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public virtual string Value { get; set; }

        private T[] _Children;
        /// <summary>
        /// 子字段，当类型为容器时有效
        /// </summary>
        public T[] Children
        {
            get { return _Children; }
            set
            {
                _Children = value;
                if (value != null)
                    foreach (var item in value)
                        item.Parent = (T)this;
            }
        }

        /// <summary>
        /// 获取完整的字段
        /// </summary>
        /// <returns></returns>
        public T[] GetFullFields()
        {
            var fieldStack = new Stack<T>();
            var currentNode = this;
            while (currentNode != null)
            {
                fieldStack.Push((T)currentNode);
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
