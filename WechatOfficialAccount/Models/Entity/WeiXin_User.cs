using SqlSugar;

namespace WechatOfficialAccount.Models.Entity
{
    public class WeiXin_User
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string openid { get; set; }
        public int sex { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public long subscribe_time { get; set; }
        public int groupid { get; set; }
        public string tagid_list { get; set; }
    }
}
