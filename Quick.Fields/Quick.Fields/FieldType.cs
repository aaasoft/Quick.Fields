using System;
using System.Collections.Generic;
using System.Text;

namespace Quick.Fields
{
    public enum FieldType
    {
        /// <summary>
        /// 按钮
        /// </summary>
        Button,
        /// <summary>
        /// 消息对话框
        /// </summary>
        MessageBox,
        /// <summary>
        /// 弹出提示框
        /// </summary>
        Toast,
        /// <summary>
        /// 显示提示框
        /// </summary>
        Alert,
        /// <summary>
        /// 显示图片
        /// </summary>
        Image,
        /// <summary>
        /// 分组容器控件
        /// </summary>
        ContainerGroup,
        /// <summary>
        /// 标签容器控件，子控件为GroupBox类型
        /// </summary>
        ContainerTab,
        /// <summary>
        /// 拆分容器控件，子控件为GroupBox类型
        /// </summary>
        ContainerSplit,
        /// <summary>
        /// 隐藏输入控件
        /// </summary>
        InputHidden,
        /// <summary>
        /// 文本输入控件
        /// </summary>
        InputText,
        /// <summary>
        /// 密码输入控件
        /// </summary>
        InputPassword,
        /// <summary>
        /// 文本域控件
        /// </summary>
        InputTextArea,
        /// <summary>
        /// 数字输入控件
        /// </summary>
        InputNumber,
        /// <summary>
        /// 选择输入控件
        /// </summary>
        InputSelect,
        /// <summary>
        /// 选择文件控件
        /// </summary>
        InputFile
    }
}
