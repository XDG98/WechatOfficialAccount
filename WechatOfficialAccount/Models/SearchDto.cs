namespace WechatOfficialAccount.Models
{
    /// <summary>
    /// 列表查询Dto
    /// </summary>
    public class SearchDto
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object rows { get; set; }
    }
}
