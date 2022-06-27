namespace WechatOfficialAccount.Models.DTO
{
    /// <summary>
    /// 获取公众号已创建的标签列表Dto
    /// </summary>
    public class GetUserTagListDto
    {
        /// <summary>
        /// 标签列表
        /// </summary>
        public List<TagDto> tags { get; set; }
        /// <summary>
        /// 标签Dto
        /// </summary>
        public class TagDto
        {
            /// <summary>
            /// 标签id，由微信分配
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 标签名，UTF8编码
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 此标签下粉丝数
            /// </summary>
            public int count { get; set; }
        }
    }
}
