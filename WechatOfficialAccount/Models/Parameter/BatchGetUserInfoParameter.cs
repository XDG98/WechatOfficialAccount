namespace WechatOfficialAccount.Models.Parameter
{
    /// <summary>
    /// 批量获取用户基本信息参数
    /// </summary>
    public class BatchGetUserInfoParameter
    {
        public List<UserListData> user_list { get; set; } = new List<UserListData>();
    }
    public class UserListData
    {
        public string openid { get; set; }
        public string lang { get; set; }
    }
}
