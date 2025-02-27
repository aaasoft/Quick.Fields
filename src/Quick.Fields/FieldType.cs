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
        /// 按钮组
        /// </summary>
        ButtonGroup,
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
        /// 分页器
        /// </summary>
        Pager,
        /// <summary>
        /// 分组容器控件
        /// </summary>
        ContainerGroup,
        /// <summary>
        /// 标签容器控件，子控件为GroupBox类型
        /// </summary>
        ContainerTab,
        /// <summary>
        /// 行容器控件
        /// </summary>
        ContainerRow,
        /// <summary>
        /// 表格容器控件，子控件为ContainerTableHead、ContainerTableBody或者ContainerTableTr类型
        /// </summary>
        ContainerTable,
        /// <summary>
        /// 表格头容器控件，子控件为ContainerTableTr类型
        /// </summary>
        ContainerTableHead,
        /// <summary>
        /// 表格体容器控件，子控件为ContainerTableTr类型
        /// </summary>
        ContainerTableBody,
        /// <summary>
        /// 表格容器控件TR，子控件为ContainerTableTh或ContainerTableTd类型
        /// </summary>
        ContainerTableTr,
        /// <summary>
        /// 表格容器控件TH
        /// </summary>
        ContainerTableTh,
        /// <summary>
        /// 表格容器控件TD
        /// </summary>
        ContainerTableTd,
        /// <summary>
        /// HTML内容划分元素标签
        /// </summary>
        HtmlDiv,
        /// <summary>
        /// HTML段落标签
        /// </summary>
        HtmlParagraph,
        /// <summary>
        /// HTML预格式化标签
        /// </summary>
        HtmlPre,
        /// <summary>
        /// HTML短语标签
        /// </summary>
        HtmlSpan,
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
