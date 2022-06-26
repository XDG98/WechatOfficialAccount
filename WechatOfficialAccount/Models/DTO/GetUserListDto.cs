namespace WechatOfficialAccount.Models.DTO
{
    /// <summary>
    /// 获取用户列表Dto
    /// </summary>
    public class GetUserListDto
    {
        /// <summary>
        /// 关注该公众账号的总用户数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 拉取的 OPENID 个数，最大值为10000
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 列表数据，OPENID的列表
        /// </summary>
        public OpenIdDto data { get; set; }
        /// <summary>
        /// 拉取列表的最后一个用户的OPENID
        /// </summary>
        public string next_openid { get; set; }
    }
    /// <summary>
    /// openid Dto
    /// </summary>
    public class OpenIdDto
    {
        /// <summary>
        /// openid
        /// </summary>
        public List<string> openid { get; set; }
    }
}
