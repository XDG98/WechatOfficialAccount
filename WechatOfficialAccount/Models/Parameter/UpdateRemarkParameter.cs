namespace WechatOfficialAccount.Models.Parameter
{
    public class UpdateRemarkParameter
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 新的备注名，长度必须小于30字节
        /// </summary>
        public string remark { get; set; }
    }
}
