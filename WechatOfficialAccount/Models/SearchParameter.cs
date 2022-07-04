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
        public string? search { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string? sort { get; set; }
        /// <summary>
        /// 排序顺序： desc 降序，asc 升序
        /// </summary>
        public string? order { get; set; }
        /// <summary>
        /// 跳过条数
        /// </summary>
        public int offset { get; set; } = 0;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int limit { get; set; } = 10;
        /// <summary>
        /// 每页条数(页码从1开始)
        /// </summary>
        public int pageNumber
        {
            get
            {
                return (offset / limit) + 1;
            }
        }
    }
}
