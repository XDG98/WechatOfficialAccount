namespace WechatOfficialAccount.Models.Parameter
{
    /// <summary>
    /// 创建标签参数
    /// </summary>
    public class CreateTagParameter
    {
        /// <summary>
        /// 标签参数
        /// </summary>
        public TagParameter tag { get; set; }
        /// <summary>
        /// 标签参数
        /// </summary>
        public class TagParameter
        {
            /// <summary>
            /// 标签名
            /// </summary>
            public string name { get; set; }
        }
    }
}
