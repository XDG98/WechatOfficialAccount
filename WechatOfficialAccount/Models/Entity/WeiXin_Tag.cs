using SqlSugar;

namespace WechatOfficialAccount.Models.Entity
{
    public class WeiXin_Tag
    {
        /// <summary>
        /// 标签id，由微信分配
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
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
