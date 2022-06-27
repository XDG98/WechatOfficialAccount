namespace WechatOfficialAccount.Models.DTO
{
    /// <summary>
    /// 创建标签返回Dto
    /// </summary>
    public class CreateTagRespondDto
    {
        /// <summary>
        /// 标签返回
        /// </summary>
        public TagRespondDto tag { get; set; }
        /// <summary>
        /// 标签返回Dto
        /// </summary>
        public class TagRespondDto
        {
            /// <summary>
            /// 标签id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 标签名
            /// </summary>
            public string name { get; set; }
        }
    }
}
