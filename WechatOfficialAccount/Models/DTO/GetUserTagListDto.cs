using static WechatOfficialAccount.Models.Entity.Tag;

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
        public List<TagDetail> tags { get; set; }
    }
}
