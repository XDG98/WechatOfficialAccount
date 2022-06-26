namespace WechatOfficialAccount.Models.DTO
{
    /// <summary>
    /// 获取微信服务器IP地址
    /// </summary>
    public class GetApiDomainIpDto
    {
        /// <summary>
        /// ip_list
        /// </summary>
        public List<string> ip_list { get; set; } = new List<string>();
    }
}
