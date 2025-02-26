namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 表格控件是否交替显示行，当Type为ContainerTable时有效
        /// </summary>
        public bool? ContainerTable_Striped { get; set; }
        /// <summary>
        /// 表格控件是否有边框，当Type为ContainerTable时有效
        /// </summary>
        public bool? ContainerTable_Bordered { get; set; }
        /// <summary>
        /// 表格控件是否在行上显示停留状态，当Type为ContainerTable时有效
        /// </summary>
        public bool? ContainerTable_Hoverable { get; set; }
    }
}
