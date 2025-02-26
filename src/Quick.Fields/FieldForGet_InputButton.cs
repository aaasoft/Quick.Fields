namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 按钮控件是否显示为轮廓，当Type为InputButton时有效
        /// </summary>
        public bool? MessageBox_IsOutline { get; set; }
        /// <summary>
        /// 按钮控件是否显示为块，当Type为InputButton时有效
        /// </summary>
        public bool? MessageBox_IsBlock { get; set; }
        /// <summary>
        /// 按钮控件是否显示为大按钮，当Type为InputButton时有效
        /// </summary>
        public bool? MessageBox_IsLarge { get; set; }
        /// <summary>
        /// 按钮控件是否显示为小按钮，当Type为InputButton时有效
        /// </summary>
        public bool? MessageBox_IsSmall { get; set; }
    }
}
