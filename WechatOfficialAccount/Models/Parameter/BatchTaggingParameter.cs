namespace WechatOfficialAccount.Models.Parameter
{
    /// <summary>
    /// 批量设置标签参数
    /// </summary>
    public class BatchTaggingParameter
    {
        /// <summary>
        /// 粉丝列表
        /// </summary>
        public List<string> openid_list { get; set; }
        /// <summary>
        /// 标签id
        /// </summary>
        public int tagid { get; set; }
    }
}
