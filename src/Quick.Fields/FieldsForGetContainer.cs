namespace Quick.Fields
{
    public class FieldsForGetContainer : AbstractFieldsContainer<FieldForGet>
    {
        /// <summary>
        /// 获取字段的名称
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public string GetFieldName(params string[] fieldIds)
        {
            return GetField(fieldIds)?.Name;
        }
    }
}
