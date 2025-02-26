namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 消息框控件是否可以取消，当Type为MessageBox时有效
        /// </summary>
        public bool? MessageBox_CanCancel { get; set; }
        /// <summary>
        /// 消息框控件是否使用Pre标签，当Type为MessageBox时有效
        /// </summary>
        public bool? MessageBox_UsePreTag { get; set; }
    }
}
