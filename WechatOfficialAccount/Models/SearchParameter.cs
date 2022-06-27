namespace WechatOfficialAccount.Models
{
    /// <summary>
    /// 列表查询参数
    /// </summary>
    public class SearchParameter
    {
        /// <summary>
        /// 搜索内容
        /// </summary>
        public string search { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 跳过条数
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int limit { get; set; }
    }
}
