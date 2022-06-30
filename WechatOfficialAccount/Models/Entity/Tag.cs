namespace WechatOfficialAccount.Models.Entity
{
    public class Tag
    {
        /// <summary>
        /// 标签
        /// </summary>
        public TagDetail tag { get; set; }
        /// <summary>
        /// 标签详情
        /// </summary>
        public class TagDetail
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
