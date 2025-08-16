namespace Quick.Fields
{
    public partial class FieldForGet
    {
        /// <summary>
        /// 是否包含日期，当Type为InputDateTime时有效
        /// </summary>
        public bool? InputDateTime_IncludeDate { get; set; }
        /// <summary>
        /// 是否包含时间，当Type为InputDateTime时有效
        /// </summary>
        public bool? InputDateTime_IncludeTime { get; set; }
    }
}
